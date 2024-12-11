using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haustier_Tamagotchi
{
    internal class Hund : Haustier
    {
        public Hund(string tierName) : base(tierName) { }

        public override void sagHallo() 
        {
            Console.WriteLine($"Wuff! Ich bin {tierName} dein neuer Freund");
        }

        public void Apportieren()
        {
            Console.WriteLine($"{tierName} holt den geworfenen Ball");
            Energie -= 15;
            Zufriedenheit += 5;
        }
        public void Bellen()
        {
            Console.WriteLine($"{tierName} bellt laut: Wuff! Wuff!");
            Energie -= 5;
        }

        public void Bild()
        {
            Console.WriteLine("\n                                         :~                        @%{{}}}{%@                      \r\n                                     *%#}[))([}{%@               ##[^~~~~~-..-<}%                   \r\n                                   ]{^-:-~++***+*<}@            @]^+++***^**^*+=^{>                 \r\n                                  {)~~+*^**+=~-::-~>[@         #<=~:::.::-~=+++**>}:                \r\n                                 ~}^**+++=-::~<((>-:+}=   .:  )}*-~)[{{{]>:::~====[#                \r\n                                 )[++===-:-[#%@@%##@%[~+~:-+(>:.^%%#{##@@%#{>:..-<@                 \r\n                                  %)=-:.-[{{%     @~ .:~++@.  %@[  @      @@@@@@@@                  \r\n                       :%@         @@#{{#@%{     %.              %[ +)                              \r\n                      .{)@            (@:    @@}^    @@*]@@       {~.:>{@@@)                        \r\n                      @][=                  -    .               .{}#{.::::~%                       \r\n                     :*.{               ^@@@@@@=.:>]=[^.=]:    ]@}.:...:::.:@                       \r\n                     =^ ^               @@}^~:.@@     .--~*<]]<~::+: @.::..)#                       \r\n                      { +{               @@@@@@@  .*>*=-:..:~=^<<.  @@.:..^{                        \r\n                      @+[#@               @@@]        .~*^>^+:     @@}...^#                         \r\n                       }..<()       ..                           .@@@...[%:                         \r\n                        )~-.:<%#{*.:....~({>  %^               @#[@[[ <[@                           \r\n                        -]+..(-  :<. ({}+  .::::+}@@%}(>>){@@@+#::[ ]}^}                            \r\n                          @(}     .  [)}{. #{.......::-+^*=....: ((. [(                             \r\n                           ^. ...%({#{=  <....::-:::........:..@:[<]. +[.                           \r\n                           @....       .......::::::::::.:.:::...}[>-.  [@                          \r\n                           % ..............}{.:.::.....:.::... .)[+[[[[[[@                          \r\n                      ^}().@.........-).::....:.::~~~~--:.. .+(@%                                   \r\n                    @< ....>........:@~.::::::::::..:  +~)###%<-.:>%                                \r\n                  +)...............^{<. ......... ...--:..  ~)~ ....:]>                             \r\n                 ]^.......#::::::^#@@@}(+~:...:-{@#<...::--:.^< ..+..+=*                            \r\n                ^> ........-+%#%@{     %{%@@@@@#<*=@{-.:...=- @.   =  {@                            \r\n                {}.  .] ..*.:           .< .=..*)-  @*...}..<#@}{{{@%@)                             \r\n                  @@@@{[[}@#@+           }~..--..*)-@<:.:%}}@   -*                                  \r\n                       .                {[> .   =:~%#>@%@-                                          \r\n                                         @@%@@@%@@@                                                 ");

            Console.ReadKey();
        }
    }
}
