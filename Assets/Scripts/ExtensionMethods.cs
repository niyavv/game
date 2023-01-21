using DG.Tweening;

namespace DefaultNamespace
{
    public static class ExtensionMethods
    {
        public static void KillTween(this Tween tween)
        {
            if (tween.IsActive())
            {
                tween.Kill();
            }
        }
    }
}