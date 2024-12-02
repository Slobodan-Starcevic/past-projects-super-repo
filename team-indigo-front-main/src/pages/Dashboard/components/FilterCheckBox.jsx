export default function FilterCheckBox({ label, options, className = '' , onSelectOption}) {

    const handleOptionSelect = (chosenOption) => {
        if(onSelect){
            onSelectOption(chosenOption);
        }
    };

    return (
        <div className={`flex flex-col ${className}`}>
            {label && <p className="my-2">{label}</p>}
            {options.map((option, index) => (
                <div key={index} className="inline-flex items-center mb-1">
                    <input
                        type="radio"
                        name="options"
                        value={option}
                        className="form-checkbox text-main-blue"
                        onChange={() => handleOptionSelect(option)}
                    />
                    <span className="ml-2 text-main-blue font-light">{option}</span>
                </div>
            ))}
        </div>
    );
}
