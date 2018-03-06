using System;
using System.Collections.Generic;

namespace LazyMortal.ReusableMvc.StaticFiles
{
    public class DefaultStaticFiles : Dictionary<string, string>
    {
        [Obsolete("asp-append-version 标签无效，启用此方法，改用GetPath获取文件路径")]
        public virtual string RenderHtml(string fileType)
        {
            fileType = fileType.ToLower();
            if (TryGetValue(fileType, out var path))
            {
                switch (fileType)
                {
                    case "css":
                        return $"<link rel=\"stylesheet\" href=\"{path}\" asp-append-version=\"true\" />";
                    case "js":
                        return $"<script src=\"{path}\" asp-append-version=\"true\" type=\"text/javascript\"></script>";
                }
            }
            return null;
        }

        public virtual string GetPath(string fileType)
        {
            fileType = fileType.ToLower();
            return TryGetValue(fileType, out var path) ? path : null;
        }
    }
}