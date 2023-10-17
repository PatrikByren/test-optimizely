using EPiServer.Shell;

namespace Nackademin23.Business.Descriptor
{
    [UIDescriptorRegistration]
    public class SettingsIconDescriptor : UIDescriptor<ISettingsIcon>
    {
        public SettingsIconDescriptor()
        {
            IconClass = ContentIcons.ActionIcons.Settings;
        }
    }

    public interface ISettingsIcon
    {
    }
}
