# 🆕 TemplatingEngine

## ❓ What is My Project?
A toy implementation of a naive text templating engine

I needed a simple template engine and thought this was a suitable project to learn some nuget-package maintenance and tooling. This project will probably grow over time, but it's implementation with regards to efficiency and memory-usage will be dependent on my personal need - or if I feel I wanna satisfy my curiosity and dive into optimization.

## ⚡ Simple Example
```csharp
string template = "I love [color] [vegetable] in the [tod]";
Dictionary<string, string> keyVals = new()
{
    {"color": "red"},
    {"vegetable": "potatoes"},
    {"tod": "morning"}
};

var result = TemplatingEngine.Replace(template, keyVals);
Console.WriteLine(result);
// "I love red potatoes in the morning"
```

## 🤝 Collaborate with My Project
If you have nothing better to do, sure. Fork -> checkout new branch -> commit changes -> PR 
