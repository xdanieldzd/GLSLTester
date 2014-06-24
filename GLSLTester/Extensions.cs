using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;

namespace GLSLTester
{
    static class Extensions
    {
        public static void SetCommonImageFilter(this FileDialog fileDialog, string defaultExtension)
        {
            List<ImageCodecInfo> codecs = ImageCodecInfo.GetImageEncoders().ToList();
            string imageExtensions = string.Join(";", codecs.Select(ici => ici.FilenameExtension));
            List<string> separateFilters = new List<string>();
            foreach (ImageCodecInfo codec in codecs) separateFilters.Add(string.Format("{0} Files ({1})|{1}", codec.FormatDescription, codec.FilenameExtension.ToLowerInvariant()));
            fileDialog.Filter = string.Format("{0}|Image Files ({1})|{1}|All Files (*.*)|*.*", string.Join("|", separateFilters), imageExtensions.ToLowerInvariant());
            if (defaultExtension != null) fileDialog.FilterIndex = (codecs.IndexOf(codecs.FirstOrDefault(x => x.FormatDescription.ToLowerInvariant().Contains(defaultExtension.ToLowerInvariant()))) + 1);
            else fileDialog.FilterIndex = (codecs.Count + 1);
        }

        public static T Clone<T>(this T originalObject)
        {
            T newObject = (T)Activator.CreateInstance(originalObject.GetType());

            FieldInfo[] fields = originalObject.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Concat(originalObject.GetType().BaseType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).ToArray();

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(originalObject);
                if (field.FieldType.Namespace != originalObject.GetType().Namespace)
                    field.SetValue(newObject, value);
                else
                    field.SetValue(newObject, Clone(value));
            }

            return newObject;
        }
    }
}
