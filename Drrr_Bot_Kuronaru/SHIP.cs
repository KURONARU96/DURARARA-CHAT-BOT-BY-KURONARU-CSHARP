using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drrr_Bot_Kuronaru
{
    public class SHIP_CALC
    {

        public static string ship(string user1, string user2)
        {

            int ship_power = new Random().Next(0, 100);


            #region [PRÉ-DEFINIDO]
            ////Aria has luv
            //if (user1.ToLower() == "@kuronaru" || user1.ToLower() == "@jenni")
            //{
            //    ship_power = 100;
            //}
            ////Claire has no luv
            //if (user1.ToLower() == "claire" || user2.ToLower() == "claire" || user1.ToLower() == "claude" || user2.ToLower() == "claude")
            //{
            //    ship_power = 0;
            //}
            ////ciare or ciaude have no love as well
            //if (user1.ToLower() == "ciaire" || user2.ToLower() == "ciaire" || user1.ToLower() == "ciaude" || user2.ToLower() == "ciaude")
            //{
            //    ship_power = 0;
            //}
            ////Drass an Ursa forever
            //if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@kuronaru")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "kuronaru" && user2.ToLower() == "kuronaru")
            //{
            //    ship_power = 100;
            //}

            //if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@ninguém")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "kuronaru" && user2.ToLower() == "ninguém")
            //{
            //    ship_power = 100;
            //}
            ////Claire Exii bet "em all
            //if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@🍀🃏tabris the fool🃏🍀")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "@🍀🃏tabris the fool🃏🍀" && user2.ToLower() == "@kuronaru")
            //{
            //    ship_power = 10000;
            //}
            ////Claire Exii bet "em all
            //if (user1.ToLower() == "kuronaru" && user2.ToLower() == "🍀🃏tabris the fool🃏🍀")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "🍀🃏tabris the fool🃏🍀" && user2.ToLower() == "kuronaru")
            //{
            //    ship_power = 10000;
            //}
            ////Claire Exii bet "em all
            //if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@alice")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "@alice" && user2.ToLower() == "@kuronaru")
            //{
            //    ship_power = 10000;
            //}
            ////Claire Exii bet "em all
            //if (user1.ToLower() == "jenni" && user2.ToLower() == "kuronaru")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "kuronaru" && user2.ToLower() == "jenni")
            //{
            //    ship_power = 10000;
            //}
            //if (user1.ToLower() == "@jenni" && user2.ToLower() == "@kuronaru")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@jenni")
            //{
            //    ship_power = 10000;
            //}
            //if (user1.ToLower() == "@nick!" && user2.ToLower() == "@kuronaru")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "@kuronaru" && user2.ToLower() == "@nick!")
            //{
            //    ship_power = 10000;
            //}
            //if (user1.ToLower() == "nick!" && user2.ToLower() == "kuronaru")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "kuronaru" && user2.ToLower() == "nick!")
            //{
            //    ship_power = 10000;
            //}
            //if (user1.ToLower() == "@nick!" && user2.ToLower() == "@butaum")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "nick!" && user2.ToLower() == "butaum")
            //{
            //    ship_power = 10000;
            //}
            //if (user1.ToLower() == "@butaum" && user2.ToLower() == "@nick!")
            //{
            //    ship_power = 10000;
            //}
            //else if (user1.ToLower() == "butaum" && user2.ToLower() == "nick!")
            //{
            //    ship_power = 10000;
            //}
            ////Solomon x Nagisa
            //if (user1.ToLower() == "solomon" && user2.ToLower() == "nagisa")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "nagisa" && user2.ToLower() == "solomon")
            //{
            //    ship_power = 100;
            //}
            ////WADU WADU HEK~
            //if (user1.ToLower() == "wadu_hek" && user2.ToLower() == "exii")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "exii" && user2.ToLower() == "wadu_hek")
            //{
            //    ship_power = 100;
            //}
            ////Claire x Pan
            //if (user1.ToLower() == "claire" && user2.ToLower() == "pan")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "pan" && user2.ToLower() == "claire")
            //{
            //    ship_power = 100;
            //}
            ////Claude x Pan
            //if (user1.ToLower() == "claude" && user2.ToLower() == "pan")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "pan" && user2.ToLower() == "claude")
            //{
            //    ship_power = 100;
            //}
            ////Pan x Pizza
            //if (user1.ToLower() == "pan" && user2.ToLower() == "pizza")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "pizza" && user2.ToLower() == "pan")
            //{
            //    ship_power = 100;
            //}
            ////Claire and sheep
            //if (user1.ToLower() == "claire" && user2.ToLower() == "🐑")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "🐑" && user2.ToLower() == "claire")
            //{
            //    ship_power = 100;
            //}
            ////Claire Exii bet "em all
            //if (user1.ToLower() == "claude" && user2.ToLower() == "🐑")
            //{
            //    ship_power = 100;
            //}
            //else if (user1.ToLower() == "🐑" && user2.ToLower() == "claude")
            //{
            //    ship_power = 100;
            //}
            #endregion
            switch (ship_power)
            {
                case 0:
                    return ($"❤️MATCHMAKING❤️\n🔻\n🔺 {user2} \n {ship_power} % |          | 404 love not found💔");
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |█         | Horrível 😭");
                    break;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |██        | Horrível 😭");
                    break;
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |███       | Horrível 😭");
                    break;
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |████      | Quase lá... 😶");
                    break;
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |█████     | Quase lá... 😶");
                    break;
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |██████    | Quase lá... 😶");
                    break;
                case 69:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |██████    | ( ͡° ͜ʖ ͡°)");
                    break;
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |███████   | Muito bom 😄");
                    break;
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |████████  | Muito bom 😄");
                    break;
                case 90:
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                case 98:
                case 99:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |█████████ | Incrível 😍");
                    break;
                case 100:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |██████████| PERFEITO! ❣️");
                    break;
                case 10000:
                    return ($"❤️MATCHMAKING❤️\n🔻 {user1} \n🔺 {user2} \n {ship_power} % |██████████|███████████████████████████████████████████████████████████████");
                    break;
            }

            return "";
        }

    }
}
