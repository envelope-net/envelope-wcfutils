using Envelope.Validation;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Serializers;

namespace Envelope.WcfUtils.Saml2.Config;

public class Saml2Config : ISaml2Config, IValidable, IInitializationValidable
{
	private static readonly Lazy<ISerializer> _serializerFactory = new(() => new JsonSerializer());

	public string CurrentDirectory { get; }

	public string SpMetadataFileRelativePath { get; set; }
	public string IdpMetadataFileRelativePath { get; set; }
	public string? PostBindingHtmlFilePath { get; set; }
	public int CookieTimeoutInMinutes { get; set; }
	public int TimeToleranceSeconds { get; set; }
	public Saml2OutgoingMessagesConfig? OutgoingMessages { get; set; }
	public Saml2IncomingMessagesConfig? IncomingMessages { get; set; }
	public CertificateStoreConfig? CertificateStore { get; set; }
	public DataCacheConfig? DataCache { get; set; }
	public AssertionAttributeConfig? AssertionAttributes { get; set; }
	public string SamlRefreshUrl { get; set; }
	public int SamlRefreshInterval { get; set; }
	public int SessionExpirationOffset { get; set; }

	private EntityDescriptorType? _spMetadata;
	public EntityDescriptorType SpMetadata
	{
		get
		{
			if (_spMetadata == null)
				ReadFiles();

			return _spMetadata!;
		}
	}


	private EntityDescriptorType? _idpMetadata;
	public EntityDescriptorType IdpMetadata
	{
		get
		{
			if (_idpMetadata == null)
				ReadFiles();

			return _idpMetadata!;
		}
	}

	private string? _postBindingHtml;
	/// <summary>
	/// The post binding HTML page
	/// </summary>
	public string? PostBindingHtml
	{
		get
		{
			if (_postBindingHtml == null)
				ReadFiles();

			return _postBindingHtml;
		}
	}

	private ISerializer _serializer;
	public ISerializer Serializer
	{
		get => _serializer ??= _serializerFactory.Value;
		set => _serializer = value;
	}

	public Saml2Config(string currentDirectory)
	{
		CurrentDirectory = string.IsNullOrWhiteSpace(currentDirectory)
			? throw new ArgumentNullException(nameof(currentDirectory))
			: currentDirectory;
	}

	public void Initialize()
		=> ReadFiles();

	private bool filesRead;
	private readonly object _readFileLock = new();
	private void ReadFiles()
	{
		if (filesRead)
			return;

		lock (_readFileLock)
		{
			if (filesRead)
				return;

			var path = Path.Combine(CurrentDirectory, SpMetadataFileRelativePath);
			try
			{
				_spMetadata = Envelope.Serializer.XmlSerializerHelper.DeserializeFromXmlFile<EntityDescriptorType>(path)!;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Unable to read sp metadata from file: " + path, ex);
			}

			path = Path.Combine(CurrentDirectory, IdpMetadataFileRelativePath);
			try
			{
				_idpMetadata = Envelope.Serializer.XmlSerializerHelper.DeserializeFromXmlFile<EntityDescriptorType>(path)!;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Unable to read idp metadata from file: " + path, ex);
			}

			if (!string.IsNullOrWhiteSpace(PostBindingHtmlFilePath))
			{
				path = Path.Combine(CurrentDirectory, PostBindingHtmlFilePath);
				try
				{
					_postBindingHtml = File.ReadAllText(path)!;
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException("Unable to read idp metadata from file: " + path, ex);
				}
			}

			filesRead = true;
		}
	}

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.IfNullOrWhiteSpace(SpMetadataFileRelativePath)
			.IfNullOrWhiteSpace(IdpMetadataFileRelativePath)
			.If(TimeToleranceSeconds <= 0)
			.IfNullOrWhiteSpace(SamlRefreshUrl)
			.If(SamlRefreshInterval <= 0)
			.If(SessionExpirationOffset <= 0)
			.IfNull(OutgoingMessages)
			.Validate(IncomingMessages)
			.Validate(CertificateStore)
			.Validate(DataCache)
			.Validate(AssertionAttributes)
			;

		return validationBuilder.Build();
	}

	public List<IValidationMessage>? ValidateInitialization(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.If(!string.IsNullOrWhiteSpace(PostBindingHtmlFilePath)
					&& (PostBindingHtml == null
						|| !PostBindingHtml.Contains("{samlDestination}")
						|| !PostBindingHtml.Contains("{samlMessageType}")
						|| !PostBindingHtml.Contains("{samlMessage}")),
				"must contain strings '{samlDestination}', '{samlMessageType}' and '{samlMessage}")

			.ValidateInitialization(SpMetadata, new Dictionary<string, object> { { EntityDescriptorType.IsServiceProvider, true }, { EntityDescriptorType.IsIdentityProvider, false } })
			.ValidateInitialization(IdpMetadata, new Dictionary<string, object> { { EntityDescriptorType.IsServiceProvider, false }, { EntityDescriptorType.IsIdentityProvider, true } })
			;

		return validationBuilder.Build();
	}
}
