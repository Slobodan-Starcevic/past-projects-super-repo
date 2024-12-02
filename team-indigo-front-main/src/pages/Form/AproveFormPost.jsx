import ReportDisplay from "../Dashboard/components/ReportDisplay.jsx";
import Button from "../../Shared/ui/Button.jsx";
import React from "react";
import {postFormFull} from "../../Shared/API/postForm.jsx";
import {createPopup} from "../../Shared/popupHandler.js";

export default function AproveFormPost({data, onClose}) {

    const handlePost = async () => {
        onClose();
        postFormFull(data)
            .then(response => {
                createPopup("success", "Report created")
            })
            .catch(error => {
                console.error('Error fetching doctors:', error);
            });
    };


    return (
        <div className="fixed top-1/2 flex justify-center py-4 left-1/2 transform -translate-x-1/2 -translate-y-1/2
                        bg-blue-dark w-full md:w-[1000px] h-[90%] z-10 rounded-md ">
            <div className="flex flex-column items-center justify-center w-[60%] mb-4">
                <div className="w-[70%] bg-white rounded-md overflow-auto w-full h-full">
                    <ReportDisplay reportData={data} />
                </div>
                <Button className="w-[40%] rounded-sm mt-4" onClick={handlePost} text="Submit Form" />
            </div>
        </div>
    );
}