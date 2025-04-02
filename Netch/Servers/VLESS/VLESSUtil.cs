using Netch.Interfaces;
using Netch.Models;
using Netch.Utils;
using System.Text.RegularExpressions;
using System.Web;

namespace Netch.Servers;

public class VLESSUtil : IServerUtil
{
    public ushort Priority { get; } = 2;

    public string TypeName { get; } = "VLESS";

    public string FullName { get; } = "VLESS";

    public string ShortName { get; } = "VL";

    public string[] UriScheme { get; } = { "vless" };

    public Type ServerType { get; } = typeof(VLESSServer);

    public void Edit(Server s)
    {
        new VLESSForm((VLESSServer)s).ShowDialog();
    }

    public void Create()
    {
        new VLESSForm().ShowDialog();
    }

    public string GetShareLink(Server s)
    {
        return XrayUtils.GetVShareLink(s, "vless");
    }

    public IServerController GetController()
    {
        if (Global.Settings.Core.VLESSCore == "Xray")
            return new XrayController();
        else if (Global.Settings.Core.VLESSCore == "SingBox")
            return new SingBoxController();
        else 
            return new V2rayController();
    }

    public IEnumerable<Server> ParseUri(string text)
    {
        return XrayUtils.ParseVUri(text);
    }

    public bool CheckServer(Server s)
    {
        return true;
    }
}