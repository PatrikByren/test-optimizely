using EPiServer.Shell;

namespace Nackademin23.Business.Descriptor
{
    [UIDescriptorRegistration]
    public class CarouselIconDescriptor : UIDescriptor<ICarouselIcon>
    {
        public CarouselIconDescriptor()
        {
            IconClass = ContentIcons.ObjectIcons.Video;
        }
    }

    public interface ICarouselIcon
    {
    }
}
