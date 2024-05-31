using System;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        return obj is FacialFeatures features &&
               EyeColor == features.EyeColor &&
               PhiltrumWidth == features.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object obj)
    {
        return obj is Identity user &&
            Email == user.Email &&
            FacialFeatures.Equals(user.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    public Identity Identity { get; set; }
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

    public bool Register(Identity identity)
    {
        if (!identity.Equals(Identity))
        {
            Identity = new Identity(identity.Email, identity.FacialFeatures);
            return true;
        }
        return false;        
    }

    public bool IsRegistered(Identity identity) => identity.Equals(Identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityB == identityA;
}
