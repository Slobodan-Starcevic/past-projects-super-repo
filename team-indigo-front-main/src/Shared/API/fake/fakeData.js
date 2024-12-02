const response = [
    {
      "reports": [
        {
          "id": 1,
          "status": "Waiting",
          "type": ["Fire", "Evacuation"],
          "severity": "Medium",
          "employeeName": "John Doe",
          "date": "2024-01-07"
        },
        {
          "id": 2,
          "status": "Completed",
          "type": ["Personal Injury", "Damage"],
          "severity": "High",
          "employeeName": "Alice Smith",
          "date": "2024-01-08"
        },
        {
          "id": 3,
          "status": "Edited",
          "type": ["Fire", "Damage"],
          "severity": "Low",
          "employeeName": "Bob Johnson",
          "date": "2024-01-09"
        },
        {
          "id": 4,
          "status": "Completed",
          "type": ["Fire", "Evacuation"],
          "severity": "Medium",
          "employeeName": "Eva Brown",
          "date": "2024-01-10"
        },
        {
          "id": 5,
          "status": "Waiting",
          "type": ["Evacuation", "Damage"],
          "severity": "High",
          "employeeName": "Charlie Davis",
          "date": "2024-01-11"
        },
        {
          "id": 6,
          "status": "Waiting",
          "type": ["Personal Injury", "Fire"],
          "severity": "Low",
          "employeeName": "Grace Wilson",
          "date": "2024-01-12"
        },
        {
          "id": 7,
          "status": "Completed",
          "type": ["Damage", "Evacuation"],
          "severity": "Medium",
          "employeeName": "David Miller",
          "date": "2024-01-13"
        },
        {
          "id": 8,
          "status": "Edited",
          "type": ["Personal Injury", "Fire"],
          "severity": "High",
          "employeeName": "Fiona Taylor",
          "date": "2024-01-14"
        },
        {
          "id": 9,
          "status": "Completed",
          "type": ["Evacuation", "Damage"],
          "severity": "Low",
          "employeeName": "George White",
          "date": "2024-01-15"
        },
        {
          "id": 10,
          "status": "Waiting",
          "type": ["Fire", "Personal Injury"],
          "severity": "Medium",
          "employeeName": "Helen Clark",
          "date": "2024-01-16"
        },
        {
          "id": 11,
          "status": "Completed",
          "type": ["Evacuation", "Personal Injury"],
          "severity": "High",
          "employeeName": "Ivan Adams",
          "date": "2024-01-17"
        }
      ],
      "filterCounts": {
        "reporterCounts": {
            "John Doe": 1,
            "Alice Smith": 1,
            "Bob Johnson": 1,
            "Eva Brown": 1,
            "Charlie Davis": 1,
            "Grace Wilson": 1,
            "David Miller": 1,
            "Fiona Taylor": 1,
            "George White": 1,
            "Helen Clark": 1,
            "Ivan Adams": 1
        },
        "incidentTypeCounts": {
        "Fire": 5,
        "Evacuation": 5,
        "Personal Injury": 4,
        "Damage": 4
        },
        "severityCounts": {
            "Low": 5,
            "Medium": 5,
            "High": 5
        },
        "dateCounts": {
            "2024-01-07": 1,
            "2024-01-08": 2,
            "2024-01-09": 1,
            "2024-01-10": 1,
            "2024-01-11": 1,
            "2024-01-12": 1,
            "2024-01-13": 1,
            "2024-01-14": 1,
            "2024-01-15": 1,
            "2024-01-16": 1,
            "2024-01-17": 1
        },
        "statusCounts": {
          "Waiting": 4,
          "Edited": 2,
          "Completed": 4
        },
        "buildingCounts": {
          "Building1": 4,
          "Building2": 7
        }
      },
      "currentPage": 1,
      "totalPage": 3,
      "totalElements": 11
    }
  ]

  export default response;
  