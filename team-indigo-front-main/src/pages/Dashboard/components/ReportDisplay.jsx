import React from 'react';

const ReportDisplay = ({ reportData }) => {
    const renderBoolean = (value) => value ? 'Yes' : 'No';

    return (
        <div className="report-display h-100 overflow-y-auto bg-white p-3 shadow-lg">

            <div className="section">
                <p className="mt-3 text-main-blue text-2xl">
                    Reporter
                </p>
                <div className="ml-5">
                    <div><span className="key">Name:</span> <span className="value">{reportData.reporter.name}</span></div>
                    <div><span className="key">Department:</span> <span className="value">{reportData.reporter.department}</span></div>
                    <div><span className="key">Phone:</span> <span className="value">{reportData.reporter.phone}</span></div>
                    <div><span className="key">Email:</span> <span className="value">{reportData.reporter.email}</span></div>
                </div>
            </div>

            {reportData.incident.typeOfIncident.includes("Injured Person") &&
                (
                    <div className="section">
                        <p className="mt-3 text-main-blue text-2xl">
                            Injured person
                        </p>
                        <div className="ml-5">
                            <div><span className="key">Name:</span> <span className="value">{reportData.injuredPerson.name}</span></div>
                            <div><span className="key">Department:</span> <span className="value">{reportData.injuredPerson.department}</span></div>
                            <div><span className="key">Phone:</span> <span className="value">{reportData.injuredPerson.phone}</span></div>
                            <div><span className="key">Email:</span> <span className="value">{reportData.injuredPerson.email}</span></div>
                            <div><span className="key">Position:</span> <span className="value">{reportData.injuredPerson.position}</span></div>
                            <p className="mt-3 text-main-blue text-2xl">
                                Supervisor
                            </p>
                            <div className="ml-5 mb-4">
                                <div><span className="key">Supervisor Name:</span> <span className="value">{reportData.injuredPerson.supervisor.name}</span></div>
                                <div><span className="key">Supervisor Phone:</span> <span className="value">{reportData.injuredPerson.supervisor.phone}</span></div>
                                <div><span className="key">Informed:</span> <span className="value">{renderBoolean(reportData.injuredPerson.supervisor.informed)}</span></div>
                            </div>
                            <div><span className="key">Go To:</span> <span className="value">{reportData.injuredPerson.goTo}</span></div>
                            <div className="ml-5">
                                {reportData.injuredPerson.goTo === 'A&E' && (
                                    <div className="subsection">
                                        <p className="mt-3 text-main-blue text-2xl">
                                            A&E
                                        </p>
                                        <div><span className="key">A&E Name:</span> <span className="value">{reportData.injuredPerson.aande.name}</span></div>
                                        <div><span className="key">A&E Section:</span> <span className="value">{reportData.injuredPerson.aande.section}</span></div>
                                        <div><span className="key">A&E Details:</span> <span className="value">{reportData.injuredPerson.aande.details}</span></div>
                                    </div>
                                )}

                                {reportData.injuredPerson.goTo === 'Hospitalization' && (
                                    <div className="subsection">
                                        <p className="mt-3 text-main-blue text-2xl">
                                            Hospital
                                        </p>
                                        <div><span className="key">Hospital Name:</span> <span className="value">{reportData.injuredPerson.hospital.name}</span></div>
                                        <div><span className="key">Hospital Section:</span> <span className="value">{reportData.injuredPerson.hospital.section}</span></div>
                                        <div><span className="key">Hospital Details:</span> <span className="value">{reportData.injuredPerson.hospital.details}</span></div>
                                    </div>
                                )}

                                {reportData.injuredPerson.goTo === 'General practitioner' && (
                                    <div className="subsection">
                                        <p className="mt-3 text-main-blue text-2xl">
                                            GP
                                        </p>
                                        <div><span className="key">GP Name:</span> <span className="value">{reportData.injuredPerson.gpDetails.name}</span></div>
                                        <div><span className="key">GP Section:</span> <span className="value">{reportData.injuredPerson.gpDetails.section}</span></div>
                                        <div><span className="key">GP Details:</span> <span className="value">{reportData.injuredPerson.gpDetails.details}</span></div>
                                    </div>
                                )}

                                {reportData.injuredPerson.goTo === 'Emergency Response' && (
                                    <div className="subsection">
                                        <p className="mt-3 text-main-blue text-2xl">
                                            Emergency response details
                                        </p>
                                        <div><span className="key">Emergency Response Officer:</span> <span className="value">{reportData.injuredPerson.emergencyResponse.emergencyResponseOfficer}</span></div>
                                        <div><span className="key">Team Leader Name:</span> <span className="value">{reportData.injuredPerson.emergencyResponse.teamLeaderName}</span></div>
                                        <div><span className="key">Bandages Used:</span> <span className="value">{renderBoolean(reportData.injuredPerson.emergencyResponse.bandagesUsed)}</span></div>
                                        <div><span className="key">Extinguishers Used:</span> <span className="value">{renderBoolean(reportData.injuredPerson.emergencyResponse.extinguishersUsed)}</span></div>
                                        <div><span className="key">Call Details:</span> <span className="value">{reportData.injuredPerson.emergencyResponse.callDetails}</span></div>
                                    </div>
                                )}
                            </div>
                        </div>
                    </div>
                )
            }


            {/* Incident Section */}
            <div className="section">
                <p className="mt-3 text-main-blue text-2xl">
                    Incident
                </p>
                <div className="ml-5">
                    <div><span className="key">Type of Incident:</span> <span className="value">{reportData.incident.typeOfIncident.join(', ')}</span></div>
                    <div><span className="key">Date:</span> <span className="value">{reportData.incident.date}</span></div>
                    <div><span className="key">Time:</span> <span className="value">{reportData.incident.time}</span></div>
                    <div><span className="key">Location:</span> <span className="value">{reportData.incident.location}</span></div>
                    <div><span className="key">Work Hours:</span> <span className="value">{renderBoolean(reportData.incident.workHours)}</span></div>
                    <div><span className="key">While Working:</span> <span className="value">{renderBoolean(reportData.incident.whileWorking)}</span></div>
                    <div><span className="key">Description:</span> <span className="value">{reportData.incident.description}</span></div>
                    <div><span className="key">Environment:</span> <span className="value">{reportData.incident.environment}</span></div>
                </div>
            </div>

            {reportData.incident.typeOfIncident.includes("Damage") && (
                <div className="section ml-5">
                    <p className="mt-3 text-main-blue text-2xl">
                        Damage
                    </p>
                    <div><span className="key">Damage Description:</span> <span className="value">{reportData.damage.description}</span></div>
                </div>
            )
            }

            {/* Advanced Details Section */}
            <div className="section">
                <p className="mt-3 text-main-blue text-2xl">
                    Advanced details
                </p>
                <div className="ml-5">
                    <div><span className="key">Explanation:</span> <span className="value">{reportData.advancedDetails.explanation}</span></div>
                    <div><span className="key">Reoccurrence:</span> <span className="value">{reportData.advancedDetails.reoccurrence}</span></div>
                    <div>
                        <span className="key">Circumstances:</span>
                        <span className="value">{reportData.advancedDetails.circumstances.join(', ')}</span>
                    </div>
                    <div>
                        <span className="key">Actions:</span>
                        <span className="value">{reportData.advancedDetails.actions.join(', ')}</span>
                    </div>
                    <div>
                        <span className="key">Organization:</span>
                        <span className="value">{reportData.advancedDetails.organization.join(', ')}</span>
                    </div>
                    <div>
                        <span className="key">Severity:</span>
                        <span className="value">{reportData.advancedDetails.severity.join(', ')}</span>
                    </div>
                </div>
            </div>


            {/* Procedure Section */}
            <div className="section">
                <p className="mt-3 text-main-blue text-2xl">
                    Procedure
                </p>
                <div className="ml-5">
                    <div><span className="key">Is Procedure:</span> <span className="value">{renderBoolean(reportData.procedure.isprocedure)}</span></div>
                    <div><span className="key">Procedure Followed:</span> <span className="value">{renderBoolean(reportData.procedure.procedureFollowed)}</span></div>
                    <div><span className="key">Person Familiar:</span> <span className="value">{renderBoolean(reportData.procedure.personFamiliar)}</span></div>
                    <div><span className="key">How Likely:</span> <span className="value">{reportData.procedure.howLikely}</span></div>
                    <div><span className="key">Prevent:</span> <span className="value">{reportData.procedure.prevention.prevent}</span></div>
                    <div><span className="key">Causes:</span> <span className="value">{reportData.procedure.prevention.causes}</span></div>
                    <div><span className="key">Future Changes:</span> <span className="value">{reportData.procedure.prevention.futureChanges}</span></div>
                    <div><span className="key">Report HR:</span> <span className="value">{renderBoolean(reportData.procedure.reportHR)}</span></div>
                    {reportData.procedure.reportHR &&(
                        <div className="subsection ml-5">
                            <div><span className="key">Director Name:</span> <span className="value">{reportData.procedure.director.directorName}</span></div>
                            <div><span className="key">Recipient Name:</span> <span className="value">{reportData.procedure.director.recipientName}</span></div>
                            <div><span className="key">Date:</span> <span className="value">{reportData.procedure.director.date}</span></div>
                            <div><span className="key">Time:</span> <span className="value">{reportData.procedure.director.time}</span></div>
                            <div><span className="key">Case Number:</span> <span className="value">{reportData.procedure.director.caseNumber}</span></div>
                        </div>
                    )
                    }
                </div>
            </div>
        </div>
    );
};

export default ReportDisplay;
