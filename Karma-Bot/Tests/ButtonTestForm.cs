using System;
using System.Threading.Tasks;
using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace TelegramBotBase.Example.Tests;

public class ButtonTestForm : AutoCleanForm
{
    public ButtonTestForm()
    {
        Opened += ButtonTestForm_Opened;
    }

    private async Task ButtonTestForm_Opened(object sender, EventArgs e)
    {
        await Device.Send("Hello world! (Click 'back' to get back to Start)");
    }

    public override async Task Action(MessageResult message)
    {
        var call = message.GetData<CallbackData>();

        await message.ConfirmAction();


        if (call == null)
        {
            return;
        }

        message.Handled = true;

        switch (call.Value)
        {
            case "button1":

                await Device.Send("Button 1 pressed");

                break;

            case "button2":

                await Device.Send("Это просто конпка, не обращяй внимание");

                break;

            case "button3":

                await Device.Send("Это просто конпка, не обращяй внимание");

                break;

            case "button4":

                await Device.Send("Это просто конпка, не обращяй внимание");

                break;

            case "back":

                var st = new Menu();

                await NavigateTo(st);

                break;

            default:

                message.Handled = false;

                break;
        }
    }


    public override async Task Render(MessageResult message)
    {
        var btn = new ButtonForm();

        btn.AddButtonRow(new ButtonBase("250 гемов на Brawl Stars", new CallbackData("a", "button1").Serialize()),
                         new ButtonBase("100 Робуксов в Roblox", new CallbackData("a", "button2").Serialize()));

        btn.AddButtonRow(new ButtonBase("Аккаунт CS2", new CallbackData("a", "button3").Serialize()),
                         new ButtonBase("Чьята жопа", new CallbackData("a", "button4").Serialize()));

        btn.AddButtonRow(new ButtonBase("Наш Discord", "discord", "https://discord.gg/d7WREAdu"),
                         new ButtonBase("Наш Steam", "steam", "https://steamcommunity.com/groups/IgraKarma"),
                         new ButtonBase("Наш KarmaStore", "karmastore", "https://playerok4.com/"));

        btn.AddButtonRow(new ButtonBase("Back", new CallbackData("a", "back").Serialize()));

        await Device.Send("Выберите товар", btn);
    }
}