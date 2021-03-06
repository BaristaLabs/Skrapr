﻿namespace Skrapr
{
    using EntryPoint;

    public class CliArguments : BaseCliArguments
    {
        public CliArguments()
            : base("Skrapr")
        {
            RemoteDebuggingHost = "localhost";
            RemoteDebuggingPort = 9223;
        }

        [Option(ShortName: 'a', LongName: "attach")]
        [Help("Indicates that if a rule in the definition matches the current url to begin at that point. If not, uses the start urls.")]
        public bool Attach
        {
            get;
            set;
        }

        [Option(ShortName: 'l', LongName: "launch")]
        [Help("Indicates that the skrapr should launch a new instance at the specified debugging port.")]
        public bool Launch
        {
            get;
            set;
        }

        [Option(ShortName: 'd', LongName: "debug")]
        [Help("Indicates that the skrapr is in debug mode. Tasks marked as skipInDebug: true will be skipped.")]
        public bool Debug
        {
            get;
            set;
        }

        [OptionParameter(LongName: "remote-debugging-host")]
        [Help("Specifies the host of the remote debugger. Default is localhost.")]
        public string RemoteDebuggingHost
        {
            get;
            set;
        }

        [OptionParameter(LongName: "remote-debugging-port")]
        [Help("Specifies the port of the remote debugger. Default is 9223.")]
        public int RemoteDebuggingPort
        {
            get;
            set;
        }

        [Required]
        [Operand(Position: 1)]
        [Help("Specifies the path to the skrapr definition file to use")]
        public string SkraprDefinitionPath
        {
            get;
            set;
        }
    }
}
