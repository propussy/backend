package config

import (
	"flag"
	"os"

	"github.com/ilyakaznacheev/cleanenv"
)

type AppConfig struct {
	Environment       string            `yaml:"environment"`
	ConnectionStrings ConnectionStrings `yaml:"connection_strings"`
	HttpConfig        HttpConfig        `yaml:"http"`
}

type ConnectionStrings struct {
	Auth string `yaml:"auth"`
}

type HttpConfig struct {
	Addr string `yaml:"addr"`
	Port int    `yaml:"port"`
}

func MustLoad() *AppConfig {
	path := fetchConfigPath()

	if _, err := os.Stat(path); os.IsNotExist(err) {
		panic("Config file does not exist at path: " + path)
	} else if err != nil {
		panic("Error checking config file: " + err.Error())
	}

	var cfg AppConfig
	cleanenv.ReadConfig(path, &cfg)

	return &cfg
}

func fetchConfigPath() string {
	var path string

	flag.StringVar(&path, "config", "", "Path to config file")
	flag.Parse()

	if path == "" {
		path = os.Getenv("CONFIG_PATH")
	}

	if path == "" {
		panic("Config path must be provided via --config flag or CONFIG_PATH environment variable")
	}

	return path
}
