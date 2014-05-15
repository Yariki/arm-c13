using ARM.Core.Enums;

namespace ARM.Core.Attributes
{
	/// <summary>
	/// атрибут, котрий визначає метадату для типу
	/// </summary>
  public class ARMMetadataAttribute : ARMBaseAttribute
  {
    public eARMMetadata Metadata { get; set; }

  }
}