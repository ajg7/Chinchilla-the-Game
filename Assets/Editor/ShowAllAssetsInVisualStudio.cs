using System.IO;
using UnityEditor;

// Unity only lists scripts in the generated .csproj, so Solution Explorer hides scenes, prefabs,
// materials, etc. This adds every non-script, non-.meta file under Assets as a "None" item.
public class ShowAllAssetsInVisualStudio : AssetPostprocessor
{
    public static string OnGeneratedCSProject(string path, string content)
    {
        if (Path.GetFileName(path) != "Assembly-CSharp.csproj")
            return content;

        const string items =
            "  <ItemGroup>\r\n" +
            "    <None Include=\"Assets\**\*\" Exclude=\"Assets\**\*.cs;Assets\**\*.meta;Assets\**\*.asmdef\" />\r\n" +
            "  </ItemGroup>\r\n";

        return content.Replace("</Project>", items + "</Project>");
    }
}
