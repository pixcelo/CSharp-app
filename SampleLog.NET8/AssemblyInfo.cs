#if DEBUG
	[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "Config/App.Debug.config")]
#else
	[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "Config/App.Release.config")]
#endif