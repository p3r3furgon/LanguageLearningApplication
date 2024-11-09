using System.ComponentModel.DataAnnotations;

namespace Learning.Domain.Enums
{
    public enum MediaType
    {
        [Display(Name = "Image")]
        Image,

        [Display(Name = "Audio")]
        Audio,

        [Display(Name = "Video")]
        Video
    }
}
