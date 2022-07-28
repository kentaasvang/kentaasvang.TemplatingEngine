# 🆕 TemplatingEngine

## ❓ What is My Project?
A toy implementation of a naive text templating engine

I needed a simple template engine and thought this was a suitable project to learn some nuget-package maintenance and tooling. This project will probably grow over time, but it's implementation with regards to efficiency and memory-usage will be dependent on my personal need - or if I feel I wanna satisfy my curiosity and dive into optimization.

## ⚡ Simple Example
```csharp
TemplateEngine templateEngine = new();
string template = "I love [color] [vegetable] in the [tod]";
Dictionary<string, string> keyVals = new()
{
    {"color": "red"},
    {"vegetable": "potatoes"},
    {"tod": "morning"}
};

template.LoadTemplate(template);
var result = template.Replace(keyVals);
Console.WriteLine(result);
// "I love red potatoes in the morning"
```
**Escape characters**
```csharp
TemplateEngine templateEngine = new();
templateEngine.WithBackSlashEscapeCharacter();
string template = "I love [color] [vegetable] in the \[tod]";
Dictionary<string, string> keyVals = new()
{
    {"color": "red"},
    {"vegetable": "potatoes"},
    {"tod": "morning"}
};

template.LoadTemplate(template);
var result = template.Replace(keyVals);
Console.WriteLine(result);
// "I love red potatoes in the [tod]"
```

## 🤝 Collaborate with My Project
If you have nothing better to do, sure. Fork -> checkout new branch -> commit changes -> PR 
