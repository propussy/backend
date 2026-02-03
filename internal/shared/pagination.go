package shared

import (
	"errors"
	"math"
)

const (
	DefaultPageSize = 20
	MinPageSize     = 1
	MaxPageSize     = 100
	MinPage         = 1
)

var (
	ErrInvalidPage     = errors.New("page must be greater than 0")
	ErrInvalidPageSize = errors.New("page size must be between 1 and 100")
)

type PagedResponse[T any] struct {
	Items    []T          `json:"items"`
	Metadata PageMetadata `json:"metadata"`
}

type PageMetadata struct {
	CurrentPage int  `json:"currentPage"`
	PageSize    int  `json:"pageSize"`
	TotalPages  int  `json:"totalPage"`
	TotalItems  int  `json:"totalItems"`
	HasNext     bool `json:"hasNext"`
	HasPrevious bool `json:"hasPrevious"`
}

type PaginationRequest struct {
	Page     int `json:"page" form:"page" query:"page"`
	PageSize int `json:"pageSize" form:"pageSize" query:"pageSize"`
}

func (r *PaginationRequest) Validate() error {
	if r.PageSize == 0 {
		r.PageSize = MinPageSize
	}

	if r.Page == 0 {
		r.Page = MinPage
	}

	if r.Page <= 0 {
		return ErrInvalidPage
	}

	if r.PageSize <= MinPageSize || r.PageSize > MaxPageSize {
		return ErrInvalidPageSize
	}

	return nil
}

func Paginate[T any](items []T, req PaginationRequest) (*PagedResponse[T], error) {
	if err := req.Validate(); err != nil {
		return nil, err
	}

	total := len(items)
	totalPages := int(math.Ceil(float64(total) / float64(req.PageSize)))

	return &PagedResponse[T]{
		Items: items,
		Metadata: PageMetadata{
			CurrentPage: req.Page,
			PageSize:    req.PageSize,
			TotalItems:  total,
			TotalPages:  totalPages,
			HasNext:     req.Page == totalPages,
			HasPrevious: req.Page == MinPage,
		},
	}, nil
}
