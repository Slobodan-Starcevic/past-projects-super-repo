//placeholder has the default empty string if nothing is passed, making it optional
//required parameter has default false, if you want to pass true, do it like >> <Input ... required={true} .../>
export default function Input({ name='', label, value = "",  type='text', placeholder = '', required = false, className = '', onChange, disabled = false}) {

    return (
        <div className={`flex flex-col z-1 ${className}`}>
            {name && <p className="m-2 mb-1 text-main-blue font-light">{label}</p>}
            <input
            type={type === "password" ? "password" : "text"}
            name={name}
            value={value}
            className='h-full box-border border border-solid mr-[10px] mb-[10px] p-[14px] rounded-sm block relative text-sm text-[#333]'
            placeholder={placeholder}
            onChange={onChange}
            required={required}
            disabled={disabled}
            />
        </div>
    );
}