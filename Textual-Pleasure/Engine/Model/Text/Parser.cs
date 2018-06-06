using Engine.ViewModel;

namespace Engine.Model.Text
{
    public class Parser
    {
        // Goals of this class: Parse text given from some source and print to screen

        // Additional functionality:
        // Separate based on tags, implement search functions, inject other objects' descriptions
        
        // Formatting basis:
        // "Hello $Player:Name$, I am $Speaker:Name$, I have $Speaker:Arms:Count$.
        // You are looking $br($Speaker:Attraction($Player$)$ > 10 then "quite lovely" else "nice") today!"

        public GameSession session;

        public Parser(GameSession session)
        {
            this.session = session;
        }

        public string ConvertParse(string text)
        {



            return text;
        }

        public string RawParse(string text)
        {



            return text;
        }
    }
}