export default function CheckboxRadioGroup({
                                               name,
                                               label,
                                               options = [],
                                               type = 'checkbox',
                                               onChange,
                                               value = (type === 'checkbox' ? [] : ''),
                                               className = ''
                                           }) {

    const isOptionSelected = (option) => {
        return type === 'checkbox' ? value.includes(option) : value === option;
    };

    return (
        <div className={`flex flex-col ${className}`}>
            <p className="my-2">
                {label}
            </p>
            {options.map((option, index) => (
                <label key={index} className="inline-flex items-center mb-1">
                    <input
                        type={type}
                        name={name}
                        value={option}
                        onChange={onChange}
                        checked={isOptionSelected(option)} // Correctly check for selected option
                        className="w-[18px] h-[18px] form-checkbox text-[#003f75] cursor-pointer rounded-full outline-0 mr-2"
                    />
                    <span className="text-sm text-black cursor-pointer">{option}</span>
                </label>
            ))}
        </div>
    );
}
