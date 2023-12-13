var hdata = {
    "name": "AGENCY", "imageUrl": "../../../../images/lead_MainPage.jpg", "area": "", "profileUrl": "../../../../images/lead_MainPage.jpg", "office": "NA",
    "tags": "NA", "isLoggedUser": false, "unit": { "type": "business", "value": "Business first" },
    "positionName": "NA", "children": [{
        "name": "AGENCY", "ImageUrl": "NA", "area": "", "profileUrl": "NA",
        "office": "NA", "isLoggedUser": "false", "unit": "{ }", "positionName": "NA"
    }, { "name": "AGENCY PARNER", "ImageUrl": "NA", "area": "", "profileUrl": "NA", "office": "NA", "isLoggedUser": "false", "unit": "{ }", "positionName": "NA" }]
}






function queryString(key) {
    //////debugger;
    strFunctionName = "queryString";
    var page = new PageQuery(window.location.search);
    //Added by AshishP for VAPT
    if (unescape(page.getValue(key)) == 'false')
        return unescape(page.getValue(key));
    else
        return atob(unescape(page.getValue(key)));
    //Added by AshishP for VAPT
}


function getParameterByName(name) {
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}


    //"children": [
    //    {
    //        "name": "AGENCY",
    //        "imageUrl": "NA",
    //        "area": "",
    //        "profileUrl": "http://example.com/employee/profile",
    //        "office": "NA",
    //        "tags": "NA",
    //        "isLoggedUser": false,
    //        "unit": {
    //            "type": "business",
    //            "value": "Business first"
    //        },
    //        "positionName": "NA"
    //    }
//    ]
//}


//{
//    "name": "GROUP BUSINESS ECO SYSTEM",
//    "imageUrl": "NA",
//    "area": "",
//    "profileUrl": "NA",
//    "office": "NA",
//    "tags": "NA",
//    "isLoggedUser": false,
//    "unit": {
//        "type": "business",
//        "value": "Business first"
//    },
//    "positionName": "NA",
//    "children": [
//        {
//            "name": "INTERNATIONAL INSURANCE COMPANY LIMITED",
//            "imageUrl": "../../../images/Internationa_Insurance_Company_logo.jpg",
//            "area": "",
//            "profileUrl": "http://example.com/employee/profile",
//            "office": "CTO office",
//            "tags": "Ceo,tag1,manager,cto",
//            "isLoggedUser": false,
//            "unit": {
//                "type": "business",
//                "value": "Business first"
//            },
//            "positionName": ""
//        }]
//}
//            "positionName": "",
//            "children": [
//                {
//                    "name": "GROUPB SALES EMPLOYEES",
//                    "imageUrl": "../../../images/Sales_Employee_icon.jpg",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CEO office",
//                    "tags": "Ceo,tag1, tag2",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business one"
//                    },
//                    "positionName": "",
//                    "children": [
//                        {
//                            "name": "CHANNEL HEAD",
//                            "imageUrl": "../../../images/Channel_Head_Icon.jpg",
//                            "area": "",
//                            "profileUrl": "http://example.com/employee/profile",
//                            "office": "CEO office",
//                            "tags": "Ceo,tag1, tag2",
//                            "isLoggedUser": false,
//                            "unit": {
//                                "type": "department",
//                                "value": " Finance Department",
//                                "desc": "Finance Dept description"
//                            },
//                            "positionName": "",

//                            "children": [
//                                {
//                                    "name": "ZONAL HEAD",
//                                    "imageUrl": "../../../images/Zonal_Head_Icon.jpg",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CEO office",
//                                    "tags": "Ceo,tag1, tag2",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "department",
//                                        "value": "Finance Department"
//                                    },
//                                    "positionName": "",
//                                    "children": [
//                                        {
//                                            "name": "BRANCH HEAD",
//                                            "imageUrl": "../../../images/Branch_Head_icon.jpg",
//                                            "area": "",
//                                            "profileUrl": "http://example.com/employee/profile",
//                                            "office": "CEO office",
//                                            "tags": "Ceo,tag1, tag2",
//                                            "isLoggedUser": false,
//                                            "unit": {
//                                                "type": "department",
//                                                "value": "Finance Department"
//                                            },
//                                            "positionName": "",
//                                            "children": [
//                                                {
//                                                    "name": "SALES MANAGER",
//                                                    "imageUrl": "../../../images/Sales-Manager_icon.jpg",
//                                                    "area": "",
//                                                    "profileUrl": "http://example.com/employee/profile",
//                                                    "office": "CEO office",
//                                                    "tags": "Ceo,tag1, tag2",
//                                                    "isLoggedUser": false,
//                                                    "unit": {
//                                                        "type": "department",
//                                                        "value": "Finance Department"
//                                                    },
//                                                    "positionName": ""
//                                                },
//                                            ]
//                                        },
//                                    ]
//                                },
//                            ]
//                        },

//                    ]
//                },

//                {
//                    "name": "BROKER GROUP BUSINESS",
//                    "imageUrl": "../../../images/Broker_Group_Business_Icon.jpg",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CEO office",
//                    "tags": "Ceo,tag1, tag2",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business one"
//                    },
//                    "positionName": "",
//                    "children": [
//                        {
//                            "name": "BROKER",
//                            "imageUrl": "../../../images/Broker_Icon.jpg",
//                            "area": "",
//                            "profileUrl": "http://example.com/employee/profile",
//                            "office": "CEO office",
//                            "tags": "Ceo,tag1, tag2",
//                            "isLoggedUser": false,
//                            "unit": {
//                                "type": "department",
//                                "value": "Marketing Department"
//                            },
//                            "positionName": "",
//                            "children":
//                            [
//                                {
//                                    "name": "INSURANCE HEAD",
//                                    "imageUrl": "../../../images/Insurance_Head_Icon.jpg",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CEO office",
//                                    "tags": "Ceo,tag1, tag2",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "department",
//                                        "value": "Marketing Department"
//                                    },
//                                    "positionName": "",
//                                    "children":
//                                    [
//                                        {
//                                            "name": "BROKER EMPLOYEES",
//                                            "imageUrl": "../../../images/Broker_Employees_icon.jpg",
//                                            "area": "",
//                                            "profileUrl": "http://example.com/employee/profile",
//                                            "office": "CEO office",
//                                            "tags": "Ceo,tag1, tag2",
//                                            "isLoggedUser": false,
//                                            "unit": {
//                                                "type": "department",
//                                                "value": "Marketing Department"
//                                            },
//                                            "positionName": ""
//                                        }
//                                    ]
//                                }
//                            ]

//                        }

//                    ]
//                },

//                {
//                    "name": "GROUPB BUSINESS OPERATION",
//                    "imageUrl": "../../../images/Business_Operational_Icon.jpg",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CEO office",
//                    "tags": "Ceo,tag1, tag2",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business one"
//                    },
//                    "positionName": "",
//                    "children": [
//                        {
//                            "name": "GROUPB ADMINISTRATIVE OFFICER",
//                            "imageUrl": "../../../images/Administrative_Officer_Icon.jpg",
//                            "area": "",
//                            "profileUrl": "http://example.com/employee/profile",
//                            "office": "CEO office",
//                            "tags": "Ceo,tag1, tag2",
//                            "isLoggedUser": false,
//                            "unit": {
//                                "type": "department",
//                                "value": "Marketing Department"
//                            },
//                            "positionName": "",
//                            "children": [
//                                {
//                                    "name": "GROUPB OPERATION OFFICER",
//                                    "imageUrl": "../../../images/Operational_Officer_Icon.jpg",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CEO office",
//                                    "tags": "Ceo,tag1, tag2",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "department",
//                                        "value": "Marketing Department"
//                                    },
//                                    "positionName": ""
//                                }
//                            ]
//                        }

//                    ]

//                }

//            ]
//        },
//        {
//            "name": "GROUP CUSTOMER",
//            "imageUrl": "",
//            "area": "",
//            "profileUrl": "http://example.com/employee/profile",
//            "office": "CTO office",
//            "tags": "Ceo,tag1,manager,cto",
//            "isLoggedUser": false,
//            "unit": {
//                "type": "business",
//                "value": "Business first"
//            },
//            "positionName": "",
//            "children": [
//                {
//                    "name": "KRISH MARK INFOTECH INDIA PRIVATE LIMITED",
//                    "imageUrl": "",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CTO office",
//                    "tags": "Ceo,tag1,manager,cto",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business first"
//                    },
//                    "positionName": "",
//                    "children": []
//                },
//                {
//                    "name": "CMS I SYSTEM INDIA PRIVATE LIMITED",
//                    "imageUrl": "",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CTO office",
//                    "tags": "Ceo,tag1,manager,cto",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business first"
//                    },
//                    "positionName": "",
//                    "children": []
//                },
//                {
//                    "name": "ATA BANK LIMITED",
//                    "imageUrl": "../../../images/",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CTO office",
//                    "tags": "Ceo,tag1,manager,cto",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business first"
//                    },
//                    "positionName": "",
//                    "children": [
//                        {
//                            "name": "ATA BANK LIMITED",
//                            "imageUrl": "",
//                            "area": "",
//                            "profileUrl": "http://example.com/employee/profile",
//                            "office": "CTO office",
//                            "tags": "Ceo,tag1,manager,cto",
//                            "isLoggedUser": false,
//                            "unit": {
//                                "type": "business",
//                                "value": "Business first"
//                            },
//                            "positionName": "HO",
//                            "children": [
//                                {
//                                "name": "COC",
//                                "imageUrl": "",
//                                "area": "",
//                                "profileUrl": "http://example.com/employee/profile",
//                                "office": "CTO office",
//                                "tags": "Ceo,tag1,manager,cto",
//                                "isLoggedUser": false,
//                                "unit": {
//                                    "type": "business",
//                                    "value": "Business first"
//                                },
//                                "positionName": "HO USER",
//                                "children": []
//                                },
//                                {
//                                    "name": "CAO",
//                                    "imageUrl": "",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "HO USER",
//                                    "children": []
//                                },
//                                {
//                                    "name": "COM",
//                                    "imageUrl": "",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "HO USER",
//                                    "children": []
//                                },
//                                {
//                                    "name": "EAST REIGON",
//                                    "imageUrl": "../../../images/Regional_Office_Icon.png",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "",
//                                    "children": []
//                                },
//                                {
//                                    "name": "WEST REIGON",
//                                    "imageUrl": "../../../images/Regional_Office_Icon.png",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "",
//                                    "children": [{
//                                        "name": "MUMBAI BRANCH",
//                                        "imageUrl": "",
//                                        "area": "",
//                                        "profileUrl": "http://example.com/employee/profile",
//                                        "office": "CTO office",
//                                        "tags": "Ceo,tag1,manager,cto",
//                                        "isLoggedUser": false,
//                                        "unit": {
//                                            "type": "business",
//                                            "value": "Business first"
//                                        },
//                                        "positionName": "",
//                                        "children": []
//                                    },
//                                        {
//                                            "name": "PUNE BRANCH",
//                                            "imageUrl": "",
//                                            "area": "",
//                                            "profileUrl": "http://example.com/employee/profile",
//                                            "office": "CTO office",
//                                            "tags": "Ceo,tag1,manager,cto",
//                                            "isLoggedUser": false,
//                                            "unit": {
//                                                "type": "business",
//                                                "value": "Business first"
//                                            },
//                                            "positionName": "",
//                                            "children": [
//                                                {
//                                                    "name": "PANKAJ RATHOR",
//                                                    "imageUrl": "",
//                                                    "area": "",
//                                                    "profileUrl": "http://example.com/employee/profile",
//                                                    "office": "CTO office",
//                                                    "tags": "Ceo,tag1,manager,cto",
//                                                    "isLoggedUser": false,
//                                                    "unit": {
//                                                        "type": "business",
//                                                        "value": "Business first"
//                                                    },
//                                                    "positionName": "BO MAKER",
//                                                    "children": []
//                                                },
//                                                {
//                                                    "name": "AMIT TIWARI",
//                                                    "imageUrl": "",
//                                                    "area": "",
//                                                    "profileUrl": "http://example.com/employee/profile",
//                                                    "office": "CTO office",
//                                                    "tags": "Ceo,tag1,manager,cto",
//                                                    "isLoggedUser": false,
//                                                    "unit": {
//                                                        "type": "business",
//                                                        "value": "Business first"
//                                                    },
//                                                    "positionName": "BO CHECKER",
//                                                    "children": []
//                                                }
//                                            ]
//                                        },
//                                        {
//                                            "name": "POOJA THAKUR",
//                                            "imageUrl": "",
//                                            "area": "",
//                                            "profileUrl": "http://example.com/employee/profile",
//                                            "office": "CTO office",
//                                            "tags": "Ceo,tag1,manager,cto",
//                                            "isLoggedUser": false,
//                                            "unit": {
//                                                "type": "business",
//                                                "value": "Business first"
//                                            },
//                                            "positionName": "RO MAKER",
//                                            "children": []
//                                        },
//                                        {
//                                            "name": "RAHUL RAJ",
//                                            "imageUrl": "",
//                                            "area": "",
//                                            "profileUrl": "http://example.com/employee/profile",
//                                            "office": "CTO office",
//                                            "tags": "Ceo,tag1,manager,cto",
//                                            "isLoggedUser": false,
//                                            "unit": {
//                                                "type": "business",
//                                                "value": "Business first"
//                                            },
//                                            "positionName": "RO CHECKER",
//                                            "children": []
//                                        }
//                                    ]
//                                },
//                                {
//                                    "name": "NORTH REIGON",
//                                    "imageUrl": "../../../images/Regional_Office_Icon.png",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "",
//                                    "children": []
//                                },
//                                {
//                                    "name": "SOUTH REIGON",
//                                    "imageUrl": "../../../images/Regional_Office_Icon.png",
//                                    "area": "",
//                                    "profileUrl": "http://example.com/employee/profile",
//                                    "office": "CTO office",
//                                    "tags": "Ceo,tag1,manager,cto",
//                                    "isLoggedUser": false,
//                                    "unit": {
//                                        "type": "business",
//                                        "value": "Business first"
//                                    },
//                                    "positionName": "",
//                                    "children": []
//                                }

//                            ]
//                        }

//                    ]
//                },
//                {
//                    "name": "CHECKERS INDIA PRIVATE LIMITED",
//                    "imageUrl": "../../../images/",
//                    "area": "",
//                    "profileUrl": "http://example.com/employee/profile",
//                    "office": "CTO office",
//                    "tags": "Ceo,tag1,manager,cto",
//                    "isLoggedUser": false,
//                    "unit": {
//                        "type": "business",
//                        "value": "Business first"
//                    },
//                    "positionName": "",
//                    "children": []
//                }

//            ]
//        }

//    ]      
//}