using System;
using System.Collections.Generic;

namespace hrhdashboard.Extensions
{
    public class KmhflFacilityServices
    {
        public double average_rating { get; set; }
        public string category_id { get; set; }
        public int number_of_ratings { get; set; }
        public object option { get; set; }
        public string service_name { get; set; }
        public string option_name { get; set; }
        public string service_id { get; set; }
        public int service_code { get; set; }
        public string id { get; set; }
        public string category_name { get; set; }
    }

    public class LatestApprovalOrRejection
    {
        public string comment { get; set; }
        public string id { get; set; }
    }

    public class ResultFacilities
    {
        public string id { get; set; }
        public string regulatory_status_name { get; set; }
        public string facility_type_name { get; set; }
        public string facility_type_parent { get; set; }
        public string owner_name { get; set; }
        public string owner_type_name { get; set; }
        public string owner_type { get; set; }
        public string operation_status_name { get; set; }
        public string county { get; set; }
        public string constituency { get; set; }
        public string constituency_name { get; set; }
        public string ward_name { get; set; }
        public double average_rating { get; set; }
        public List<KmhflFacilityServices> facility_services { get; set; }
        public bool is_approved { get; set; }
        public bool has_edits { get; set; }
        public object latest_update { get; set; }
        public string regulatory_body_name { get; set; }
        public string owner { get; set; }
        public DateTime date_requested { get; set; }
        public DateTime date_approved { get; set; }
        public LatestApprovalOrRejection latest_approval_or_rejection { get; set; }
        public string sub_county_name { get; set; }
        public string sub_county_id { get; set; }
        public string county_name { get; set; }
        public string constituency_id { get; set; }
        public string county_id { get; set; }
        public string keph_level_name { get; set; }
        public List<double> lat_long { get; set; }
        public bool is_complete { get; set; }
        public string in_complete_details { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public bool deleted { get; set; }
        public bool active { get; set; }
        public object search { get; set; }
        public string name { get; set; }
        public string official_name { get; set; }
        public string code { get; set; }
        public string registration_number { get; set; }
        public object abbreviation { get; set; }
        public object description { get; set; }
        public int number_of_beds { get; set; }
        public int number_of_cots { get; set; }
        public bool open_whole_day { get; set; }
        public bool open_public_holidays { get; set; }
        public bool open_normal_day { get; set; }
        public bool open_weekends { get; set; }
        public bool open_late_night { get; set; }
        public bool is_classified { get; set; }
        public bool is_published { get; set; }
        public object attributes { get; set; }
        public bool regulated { get; set; }
        public bool approved { get; set; }
        public bool rejected { get; set; }
        public string bank_name { get; set; }
        public string branch_name { get; set; }
        public string bank_account { get; set; }
        public int? facility_catchment_population { get; set; }
        public string town_name { get; set; }
        public string nearest_landmark { get; set; }
        public string plot_number { get; set; }
        public string location_desc { get; set; }
        public bool closed { get; set; }
        public object closed_date { get; set; }
        public object closing_reason { get; set; }
        public string date_established { get; set; }
        public string license_number { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public string facility_type { get; set; }
        public string operation_status { get; set; }
        public string ward { get; set; }
        public object parent { get; set; }
        public string regulatory_body { get; set; }
        public string keph_level { get; set; }
        public string sub_county { get; set; }
        public object town { get; set; }
        public string regulation_status { get; set; }
        public List<string> contacts { get; set; }
    }

    public class ResultContacts
    {
        public string contact_type { get; set; }
        public string actual_contact { get; set; }
    }

    public class KmhflFacilitiesObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public int page_size { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public List<int> near_pages { get; set; }
        public List<int> far_pages { get; set; }
        public List<ResultFacilities> results { get; set; }
    }

    public class KmhflContactsObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public int page_size { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public List<int> near_pages { get; set; }
        public List<int> far_pages { get; set; }
        public List<ResultContacts> results { get; set; }
    }
}
