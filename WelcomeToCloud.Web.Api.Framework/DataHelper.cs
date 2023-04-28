using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelcomeToCloud.Web.Api.Framework
{
    public class DataHelper
    {
        private string[] _list;
        private Random _random= new Random();
        public DataHelper()
        {
            _list = FillDataCollection();
        }
        public string GetRandomFact()
        {
            return _list[_random.Next(_list.Length)];
        }
        private string[] FillDataCollection()
        {
            List<string> list = new List<string>();
            list.Add("Avocados are a fruit, not a vegetable. They're technically considered a single-seeded berry, believe it or not.");
            list.Add("The Eiffel Tower can be 15 cm taller during the summer, due to thermal expansion meaning the iron heats up, the particles gain kinetic energy and take up more space.");
            list.Add("Trypophobia is the fear of closely-packed holes. Or more specifically, \"an aversion to the sight of irregular patterns or clusters of small holes or bumps.\" No crumpets for them, then.");
            list.Add("Allodoxaphobia is the fear of other people's opinions. It's a rare social phobia that's characterised by an irrational and overwhelming fear of what other people think.");
            list.Add("Australia is wider than the moon. The moon sits at 3400km in diameter, while Australia’s diameter from east to west is almost 4000km.");
            list.Add("'Mellifluous' is a sound that is pleasingly smooth and musical to hear.");
            list.Add("The Spice Girls were originally a band called Touch. \"When we first started [with the name Touch], we were pretty bland,\" Mel C told The Guardian in 2018. \"We felt like we had to fit into a mould.\"");
            list.Add("Emma Bunton auditioned for the role of Bianca Butcher in Eastenders. Baby Spice already had a small part in the soap back in the 90s but tried out for a full-time role. She was pipped to the post by Patsy Palmer but ended up auditioning for the Spice Girls not long after.");
            list.Add("Human teeth are the only part of the body that cannot heal themselves. Teeth are coated in enamel which is not a living tissue.");
            list.Add("It's illegal to own just one guinea pig in Switzerland. It's considered animal abuse because they're social beings and get lonely.");
            list.Add("The Ancient Romans used to drop a piece of toast into their wine for good health - hence why we 'raise a toast'.");
            list.Add("The heart of a shrimp is located in its head. They also have an open circulatory system, which means they have no arteries and their organs float directly in blood.");
            list.Add("When i was little, my mom was big");
            return list.ToArray();
        }
    }
}