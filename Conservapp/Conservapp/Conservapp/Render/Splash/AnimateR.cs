using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Conservapp.Render.Splash
{
    public class AnimateR
    {
        public static async Task BallAnimate(View view, int Top, int reduce, int time)
        {
            try
            {
                await view.RelRotateTo(360, 1000);
                do
                {
                    await view.TranslateTo(view.TranslationX, view.TranslationY - Top, 500, Easing.CubicOut);

                    await view.TranslateTo(view.TranslationX, view.TranslationY + Top, 300, Easing.CubicIn);

                    Top = Top - reduce;
                    time--;
                } while (time != 0);
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }

            /*
            await view.TranslateTo(view.TranslationX, view.TranslationY - 50, 500, Easing.Linear);

            await view.TranslateTo(view.TranslationX, view.TranslationY + 50, 300, Easing.Linear);

            await view.TranslateTo(view.TranslationX, view.TranslationY - 20, 300, Easing.Linear);

            await view.TranslateTo(view.TranslationX, view.TranslationY + 20, 150, Easing.Linear);

            await view.TranslateTo(view.TranslationX, view.TranslationY - 10, 150, Easing.Linear);

            await view.TranslateTo(view.TranslationX, view.TranslationY + 10, 100, Easing.Linear);

            await view.FadeTo(-0, 1000);
            */
        }
    }
}
