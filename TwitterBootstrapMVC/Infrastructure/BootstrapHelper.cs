using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Infrastructure
{
    public static class BootstrapHelper
    {
        public static string GetClassForButtonSize(ButtonSize buttonSize)
        {
            if (buttonSize == ButtonSize.Large) return "btn-large";
            if (buttonSize == ButtonSize.Small) return "btn-small";
            if (buttonSize == ButtonSize.Mini) return "btn-mini";
            return string.Empty;
        }

        public static string GetClassForButtonStyle(ButtonStyle buttonStyle)
        {
            if (buttonStyle == ButtonStyle.Primary) return "btn-primary";
            if (buttonStyle == ButtonStyle.Info) return "btn-info";
            if (buttonStyle == ButtonStyle.Success) return "btn-success";
            if (buttonStyle == ButtonStyle.Warning) return "btn-warning";
            if (buttonStyle == ButtonStyle.Danger) return "btn-danger";
            if (buttonStyle == ButtonStyle.Inverse) return "btn-inverse";
            if (buttonStyle == ButtonStyle.Link) return "btn-link";
            return string.Empty;
        }

        public static string GetClassForInputSize(InputSize textBoxSize)
        {
            if (textBoxSize == InputSize.Mini) return "input-mini";
            if (textBoxSize == InputSize.BlockLevel) return "input-block-level";
            if (textBoxSize == InputSize.Small) return "input-small";
            if (textBoxSize == InputSize.Medium) return "input-medium";
            if (textBoxSize == InputSize.Large) return "input-large";
            if (textBoxSize == InputSize.XLarge) return "input-xlarge";
            if (textBoxSize == InputSize.XXLarge) return "input-xxlarge";
            return string.Empty;
        }

        public static string GetPlaceholderFromMetadata(ModelMetadata metadata)
        {
            if (metadata == null) return string.Empty;
            if (!string.IsNullOrEmpty(metadata.Watermark)) return metadata.Watermark;
            if (!string.IsNullOrEmpty(metadata.DisplayName)) return metadata.DisplayName;
            if (!string.IsNullOrEmpty(metadata.PropertyName)) return metadata.PropertyName.SplitByUpperCase();
            return string.Empty;
        }

        public static string GetHelpTextFromMetadata(ModelMetadata metadata)
        {
            if (metadata == null) return string.Empty;
            if (!string.IsNullOrEmpty(metadata.Description)) return metadata.Description;
            return string.Empty;
        }
    }
}
