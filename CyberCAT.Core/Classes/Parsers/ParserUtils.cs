using System.Collections.Generic;
using System.IO;
using System.Linq;
using CyberCAT.Core.Classes.Interfaces;

namespace CyberCAT.Core.Classes.Parsers
{
    internal class ParserUtils
    {
        public static void ParseChildren(IEnumerable<NodeEntry> children, BinaryReader reader, List<INodeParser> parsers, bool primary = false)
        {
            foreach (var node in children)
            {
                if (primary) SaveFile.ReportProgress(new Mapping.SaveProgressChangedEventArgs(0, 0, node.Name));
                reader.BaseStream.Position = node.Offset;
                var parser = parsers.FirstOrDefault(p => p.ParsableNodeName == node.Name) ?? new DefaultParser();
                node.Value = parser.Read(node, reader, parsers);
                node.Parser = parser;
            }
        }
    }
}