using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["cf03abdb5d2ef1b6f0d30ae40303936f9ab22f387f8a1072e2849c8292470af1"] = "ipodtouch0218",
        ["d5ba21667a5da00967cc5ebd64c0d648e554fb671637adb3d22a688157d39bf6"] = "mindnomad",
        ["95962949aacdbb42a6123732dabe9c7200ded59d7eeb39c889067bafeebecc72"] = "MPS64",
        ["7e9c6f2eaf0ce11098c8a90fcd9d48b13017667e33d09d0cc5dfe924f3ead6c1"] = "Fawndue",
        ["c87758a5234d9719c063437231f6e29712c27ebfa8972ee63c793db1e1f4957b"] = "Lust",
        ["7677b1c69e1b86d5347826c5cac6b7f8b0b6d52bb9f73c7e910a15ee4294e7c8"] = "LustoUnity",
        ["ab6fd4f73691d9a7ab554b9c3d2795dcbbc9e4327e2715472bb159da7a4163ee"] = "LustoMobile",
        ["00ccc39e32e1fffb818761c210514b7422624cfb56e4ed1542564a0ba1504a4e"] = "Moddimation",
    };

    public static bool IsMineOrLocal(this PhotonView view) {
        return !view || view.IsMine;
    }

    public static bool HasRainbowName(this Player player) {
        if (player == null || player.UserId == null)
            return false;

        byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(player.UserId));
        StringBuilder sb = new();
        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        string hash = sb.ToString().ToLower();
        return SPECIAL_PLAYERS.ContainsKey(hash) && player.NickName == SPECIAL_PLAYERS[hash];
    }

    //public static void RPCFunc(this PhotonView view, Delegate action, RpcTarget target, params object[] parameters) {
    //    view.RPC(nameof(action), target, parameters);
    //}
}