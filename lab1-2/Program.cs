

using lab1;

var a = new TextBeforeAppenderDecorator(new TextAfterAppenderFecorator(new EuropaTime(), "ДМИ"), "ЕЛА");
var b = new TextBeforeAppenderDecorator(new TextAfterAppenderFecorator(new AmericaTime(), "ДМИ"), "ЕЛА");
var c = new TextAfterAppenderFecorator(a, "#%#$@");

Console.WriteLine(a.operation());
Console.WriteLine(b.operation());
Console.WriteLine(c.operation());