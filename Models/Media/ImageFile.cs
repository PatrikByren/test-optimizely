using EPiServer.Framework.DataAnnotations;

namespace Nackademin23.Models.Media
{
    [ContentType(GUID = "{30AA3FFF-8DFA-4481-A846-35328C22973B}")]
    [MediaDescriptor(ExtensionString ="jpg,jpeg,jpe,ico,png,gif,bmp,webp")]
    public class ImageFile : ImageData
    {

    }
}
