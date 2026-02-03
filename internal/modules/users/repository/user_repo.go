package repository

import (
	"context"
	"time"

	"github.com/propussy/backend/internal/modules/users/db"
	"github.com/propussy/backend/internal/modules/users/domain"
)

type UserRepo struct {
	queries *db.Queries
}

func NewUserRepository(q *db.Queries) *UserRepo {
	return &UserRepo{
		queries: q,
	}
}

func (r *UserRepo) ToDomain(row db.User) domain.User {
	return domain.User{
		ID:          row.ID,
		Email:       row.Email,
		Phone:       row.Phone,
		FirstName:   row.FirstName,
		LastName:    row.LastName,
		LicenceUrl:  row.LicenceUrl,
		PassportUrl: row.PassportUrl,
		Idp:         row.InternationalDrivingPermitUrl,
		DateOfBirth: time.UnixMilli(row.DateOfBirth),
		CreatedAt:   time.UnixMilli(row.CreatedAt),
	}
}

func (r *UserRepo) ToDomainSlice(rows []db.User) []domain.User {
	users := make([]domain.User, len(rows))

	for i, u := range rows {
		users[i] = r.ToDomain(u)
	}

	return users
}

func (r *UserRepo) ListUsers(ctx context.Context)
