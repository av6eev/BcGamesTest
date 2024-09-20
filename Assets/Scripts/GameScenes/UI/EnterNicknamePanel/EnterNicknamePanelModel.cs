using Awaiter;
using Reactive.Field;

namespace GameScenes.UI.EnterNicknamePanel
{
    public class EnterNicknamePanelModel
    {
        public readonly ReactiveField<bool> IsShown = new();
        public string InputNickname { get; private set; }
        public readonly CustomAwaiter ConfirmAwaiter = new();

        public void ConfirmNickname(string nickname)
        {
            InputNickname = nickname;
            ConfirmAwaiter.Complete();
        }

        public void Show()
        {
            IsShown.Value = true;
        }

        public void Hide()
        {
            IsShown.Value = false;
        }
    }
}