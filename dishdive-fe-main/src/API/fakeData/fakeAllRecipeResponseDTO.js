export const data = {
    "recipes": [
      {
        "id": "7e7ad085-4d82-4c19-8f5e-7d13c9f65c0a",
        "poster": {
          "id": "a1b2c3d4-5678-90ab-cdef-123456789abc",
          "username": "John Doe",
          "email": "john.doe@example.com",
          "password": "hashed_password",
          "userRole": "USER"
        },
        "title": "Delicious Pancakes",
        "description": "A mouth-watering pancake recipe.",
        "creationTime": "2024-01-14T08:30:00",
        "servings": 4,
        "prepTime": 15,
        "cookTime": 20,
        "recipeTag": "BREAKFAST",
        "ingredients": [
          {
            "id": "e1f2g3h4-5678-90ab-cdef-123456789abc",
            "name": "Flour"
          },
          {
            "id": "i1j2k3l4-5678-90ab-cdef-123456789abc",
            "name": "Eggs"
          },
          {
            "id": "m1n2o3p4-5678-90ab-cdef-123456789abc",
            "name": "Milk"
          }
        ],
        "rating": 4
      },
      {
        "id": "f5g6h7i8-9abc-def1-2345-6789abcde012",
        "poster": {
          "id": "b1c2d3e4-5678-90ab-cdef-123456789abc",
          "username": "Jane Smith",
          "email": "jane.smith@example.com",
          "password": "hashed_password", 
          "userRole": "USER"
        },
        "title": "Spaghetti Bolognese",
        "description": "Classic Italian pasta dish.",
        "creationTime": "2024-01-11T12:45:00",
        "servings": 6,
        "prepTime": 30,
        "cookTime": 45,
        "recipeTag": "DINNER",
        "ingredients": [
          {
            "id": "q1r2s3t4-5678-90ab-cdef-123456789abc",
            "name": "Ground Beef"
          },
          {
            "id": "u1v2w3x4-5678-90ab-cdef-123456789abc",
            "name": "Tomatoes"
          },
          {
            "id": "y1z2a3b4-5678-90ab-cdef-123456789abc",
            "name": "Onions"
          }
        ],
        "rating": 5
      }
    ],
    "filterCounts": {
      "creationTimeCounts": {
        "2024-01-15T08:30:00": 1,
        "2024-01-15T12:45:00": 1
      },
      "servingsCounts": {
        "4": 1,
        "6": 1
      },
      "cookTimeCounts": {
        "20": 1,
        "45": 1
      },
      "recipeTagCounts": {
        "BREAKFAST": 1,
        "DINNER": 1,
        "LUNCH": 0,
        "DESSERT": 0,
        "SNACK": 0
      },
      "ratingCounts": {
        "1": 0,
        "2": 0,
        "3": 0,
        "4": 1,
        "5": 1
      }
    },
    "currentPage": 1,
    "totalPages": 1,
    "totalItems": 2
  }
  