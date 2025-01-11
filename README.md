
IID & 🍺.io: [https://buymeacoffee.com/apintio](https://buymeacoffee.com/apintio) - [https://github.com/EloiStree/IID](https://github.com/EloiStree/IID) - [https://github.com/EloiStree/apint.io](https://github.com/EloiStree/apint.io)

----------------------------

[`dotnet add package be.elab.iid`](https://www.nuget.org/packages/be.elab.iid)

-------------------

# NuGet IID (Index Integer Date) 

Rust version: [crates.io/crates/iid](https://crates.io/crates/iid)  
Python version: [pypi.org/project/iid42/](https://pypi.org/project/iid42/)  
C# version: [nuget.org/packages/be.elab.iid](https://www.nuget.org/packages/be.elab.iid)  


**C# Package for IID**  
This code defines what an IID is in C#.  
It is also available in Python, C# (NuGet/Visual Studio and OpenUPM/Unity), and Rust.

IID stands for **Index Integer Date**.  
The format is: `i32, i32, u64`.  
You can learn more about it [here](https://github.com/EloiStree/IID).

The aim of IID is to enable networked shared servers to perform remote-controlled actions and support integer-based massive multiplayer games.



-------

Example:
```
using Eloi.IID;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        bool useListener = true;
        ListenUdpIID listener ;
        if (useListener)
        {
            listener = new ListenUdpIID("127.0.0.1", 3615, 0);
        }

        bool useSender = true;
        if (useSender)
        {
            SendUdpIID target = new SendUdpIID("127.0.0.1", 3615, true);
            while (true)
            {
                Console.WriteLine("Enter a number to send to the server (or type 'exit' to quit):");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(input, out int number))
                {
                    target.PushInteger(number);
                }
                else
                {
                    byte[] toPush = IIDUtility.TextShortcutToBytes(input);
                    if (toPush != null)
                    {
                        target.PushBytes(toPush);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number or text.");
                    }
                }
            }
        }

        Console.WriteLine("Press any key to quit...");
        Console.ReadKey();
    }
}
```



--------------------------------

```
/*
 * ----------------------------------------------------------------------------
 * "PIZZA LICENSE":
 * https://github.com/EloiStree wrote this file.
 * As long as you retain this notice, you
 * can do whatever you want with this code.
 * If you think my code saved you time,
 * consider sending me a 🍺 or a 🍕 at:
 *  - https://buymeacoffee.com/apintio
 * 
 * You can also support my work by building your own DIY input device
 * using these Amazon links:
 * - https://github.com/EloiStree/HelloInput
 *
 * May the code be with you.
 *
 * Updated version: https://github.com/EloiStree/License
 * ----------------------------------------------------------------------------
 */
```
