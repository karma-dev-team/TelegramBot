using System;
using System.Threading.Tasks;
using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace Karma_Bot.Tests;


public class Authorization : AutoCleanForm
{
    public override async Task Render(MessageResult message)
    {
        var btn = new ButtonForm();

        btn.AddButtonRow(new ButtonBase("Ссылка на вход", "authorization", "#"));

        btn.AddButtonRow(new ButtonBase("Back", new CallbackData("a", "back").Serialize()));

        await Device.Send("Выберите товар", btn);
    }
}

