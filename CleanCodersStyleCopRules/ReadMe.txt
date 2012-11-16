CleanCodersStyleCopRules

Simply put, this StyleCop add-in or plug-in contains 25 rules, all extracted from the book Clean Code by Robert C. Martin. This package is fully tested with NUnit and is very straight forward to understand.

This project was born out of frustration. I wanted to have the simplest way to create StyleCop custom rules, while being able to test them with NUnit.

As it turns out, there are many custom rules out there, there are also packages pre made such as StyleCop+, StyleCop Contrib and StyleCopCustomRuleCleanCode.

None of them please me and fulfilled my needs. This project began rather small. As it grew, I had to refactor it. I found myself going from concrete classes to static implementation, and used the good ideas I found in available custom rules to create this package. Hence, some things may look similar to what is done in other packages, mainly the packages listed above.

I have not reinvented the wheel here. Some of the rules in this package are experimental. Specially the one that deals with plural variable names. It ain't perfect. I feel it shall be an FxCop rule, but I wanted to give it a try with StyleCop. It does OK, catches most of the things but is far, far from being perfect.

I also took a lazy approach in some rules, parsing directly the source code instead of walking it with tokens. Again, this sounded simpler to do, and was, hence the reason you will find it in here.

Other than that, I decided to use string properties instead of CollectionProperty because StyleCop does not implement a default value for Collections. That meant I could not get the code to behave correctly if no Settings.StyleCop configuration was found for this package. That is why you will find string properties space delimited for the hungarian prefix validation. Within the code, I split the string property to make it a list.

You will not find a GUI implementation to graphically configure this package. Again, I want to keep things simple so, you will have to configure it manually, or simply live with the default values. Either way, you can find a sample Settings.StyleCop file within the package.

I tried to name the rules after what can be found in the Clean Code book by Robert C. Martin, and the rule number simply refer to the page of the book where the rule is explained.

Some of the custom rule found here are "not directly" discussed in Clean Code, but I managed to tie them into something that was in the book.

I for one, run all StyleCop rules in my code on top of the ones in this package. I find by running StyleCop as a plugin within JetBrains' Resharper is something that in my mind, every good C# programmer should be doing. It makes things so much simpler....

There are 3 DLLs being referenced in the two projects. StyleCop.dll, StyleCop.CSharp.dll and nunit.framework. The two StyleCop references are the DLL that are installed when you install StyleCop on your machine. You can simply copy your installation DLL over the ones found inside the lib directory or redo the references to point directly to your StyleCop installed DLL. Same goes for the NUnit DLL.

I structured the project this way so it can be compiled without StyleCop and Nunit installed. You simply have to update it for your specific software versions.

This package is compiled in .NET 3.5. I do not know why, but compiled in .NET 4.0 it simply wouldn't work with StyleCop. I guess it is a known issue.

That's it.

Jean.Francois.Talbot
