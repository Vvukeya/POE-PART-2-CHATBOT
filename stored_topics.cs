using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART_2_CHATBOT
{
    internal class stored_topics
    {
        // Store cybersecurity topics and ignore words
        public void store_topics(ArrayList topics, ArrayList ignore)
        {
            topics.Add("Always use strong passwords with a mix of letters, numbers, and symbols.");
            topics.Add("Be cautious of phishing emails that ask for personal information.");
            topics.Add("Enable multi-factor authentication (MFA) for extra security.");
            topics.Add("safe browsing");
            topics.Add("password.");
            topics.Add("phising");
            topics.Add("malware");
            topics.Add("ransomware");
            // topics.Add("social engineering");
            store_ignore(ignore);
        }

        // Store words to ignore during input processing
        public void store_ignore(ArrayList ignore)
        {
            ignore.Add("What"); ignore.Add("is"); ignore.Add("the"); ignore.Add("capital"); ignore.Add("of");
            ignore.Add("a"); ignore.Add("an"); ignore.Add("and"); ignore.Add("or"); ignore.Add("in");
            ignore.Add("on"); ignore.Add("at"); ignore.Add("to"); ignore.Add("from"); ignore.Add("with");
            ignore.Add("by"); ignore.Add("for"); ignore.Add("about"); ignore.Add("as"); ignore.Add("into");
            ignore.Add("like"); ignore.Add("through"); ignore.Add("over"); ignore.Add("between"); ignore.Add("under");
            ignore.Add("against"); ignore.Add("during"); ignore.Add("without"); ignore.Add("before"); ignore.Add("after");
            ignore.Add("above"); ignore.Add("below"); ignore.Add("around"); ignore.Add("upon"); ignore.Add("among");
            ignore.Add("behind"); ignore.Add("beneath"); ignore.Add("beside"); ignore.Add("between"); ignore.Add("beyond");
            ignore.Add("inside"); ignore.Add("outside"); ignore.Add("throughout"); ignore.Add("towards"); ignore.Add("underneath");
            ignore.Add("within"); ignore.Add("without"); ignore.Add("I"); ignore.Add("you"); ignore.Add("he");
            ignore.Add("she"); ignore.Add("it"); ignore.Add("we"); ignore.Add("they"); ignore.Add("me");
            ignore.Add("him"); ignore.Add("her"); ignore.Add("us"); ignore.Add("them"); ignore.Add("my");
            ignore.Add("mine"); ignore.Add("your"); ignore.Add("yours"); ignore.Add("his"); ignore.Add("her");
            ignore.Add("hers"); ignore.Add("its"); ignore.Add("our"); ignore.Add("ours"); ignore.Add("their");
            ignore.Add("theirs"); ignore.Add("this"); ignore.Add("that"); ignore.Add("these"); ignore.Add("those");
            ignore.Add("who"); ignore.Add("whom"); ignore.Add("whose"); ignore.Add("which"); ignore.Add("what");
            ignore.Add("where"); ignore.Add("when"); ignore.Add("why"); ignore.Add("how"); ignore.Add("all");
            ignore.Add("any"); ignore.Add("both"); ignore.Add("each"); ignore.Add("few"); ignore.Add("more");
            ignore.Add("most"); ignore.Add("other"); ignore.Add("some"); ignore.Add("such"); ignore.Add("no");
            ignore.Add("nor"); ignore.Add("not"); ignore.Add("only"); ignore.Add("own"); ignore.Add("same");
            ignore.Add("so"); ignore.Add("than"); ignore.Add("too"); ignore.Add("very"); ignore.Add("s"); ignore.Add("t");
            ignore.Add("can"); ignore.Add("will"); ignore.Add("just"); ignore.Add("don"); ignore.Add("should");
            ignore.Add("now"); ignore.Add("d"); ignore.Add("ll"); ignore.Add("m"); ignore.Add("o"); ignore.Add("re");
            ignore.Add("ve"); ignore.Add("y"); ignore.Add("ain"); ignore.Add("aren"); ignore.Add("couldn");
            ignore.Add("didn"); ignore.Add("doesn"); ignore.Add("hadn"); ignore.Add("hasn"); ignore.Add("haven");
            ignore.Add("isn"); ignore.Add("ma"); ignore.Add("mightn"); ignore.Add("mustn"); ignore.Add("needn");
            ignore.Add("shan"); ignore.Add("shouldn"); ignore.Add("wasn"); ignore.Add("weren"); ignore.Add("won");
            ignore.Add("wouldn"); ignore.Add("play"); ignore.Add("I'll"); ignore.Add("we'll"); ignore.Add("you'll");
            ignore.Add("he'll"); ignore.Add("she'll"); ignore.Add("it'll"); ignore.Add("they'll"); ignore.Add("I'm");
            ignore.Add("we're"); ignore.Add("you're"); ignore.Add("he's"); ignore.Add("she's"); ignore.Add("it's");
            ignore.Add("they're"); ignore.Add("I've"); ignore.Add("we've"); ignore.Add("you've"); ignore.Add("he's");
            ignore.Add("she's"); ignore.Add("it's"); ignore.Add("they've"); ignore.Add("I'd"); ignore.Add("we'd");
            ignore.Add("you'd"); ignore.Add("he'd"); ignore.Add("she'd"); ignore.Add("it'd"); ignore.Add("they'd");
            ignore.Add("I'm"); ignore.Add("we're"); ignore.Add("you're"); ignore.Add("he's"); ignore.Add("she's");
            ignore.Add("it's"); ignore.Add("they're"); ignore.Add("I've"); ignore.Add("we've"); ignore.Add("you've");
            ignore.Add("he's"); ignore.Add("she's"); ignore.Add("it's"); ignore.Add("they've"); ignore.Add("I'd");
            ignore.Add("we'd"); ignore.Add("you'd"); ignore.Add("he'd"); ignore.Add("she'd"); ignore.Add("it'd");
            ignore.Add("they'd"); ignore.Add("I'm"); ignore.Add("we're"); ignore.Add("you're"); ignore.Add("he's");
            ignore.Add("she's"); ignore.Add("it's"); ignore.Add("they're"); ignore.Add("I've"); ignore.Add("we've");
            ignore.Add("you've"); ignore.Add("he's"); ignore.Add("she's"); ignore.Add("it's"); ignore.Add("they've");
        }
    }
}