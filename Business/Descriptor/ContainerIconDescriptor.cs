using EPiServer.Shell;

namespace Nackademin23.Business.Descriptor
{
    [UIDescriptorRegistration]
    public class ContainerIconDescriptor : UIDescriptor<IContainerIcon>
    {
        public ContainerIconDescriptor()
        {
            IconClass = ContentIcons.ObjectIcons.Container;
        }
    }

    public interface IContainerIcon
    {
    }
}
