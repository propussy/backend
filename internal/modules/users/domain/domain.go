package domain

import "time"

type User struct {
	ID          string
	Email       string
	Phone       string
	FirstName   string
	LastName    string
	LicenceUrl  string
	PassportUrl string
	Idp         string
	DateOfBirth time.Time
	CreatedAt   time.Time
}

type Role struct {
	ID   string
	Name string
}
