export default function DatePicker({ name = '', type = 'date', className = '', onChange, value = '', error = '' }) {
    return (
        <div className={`flex flex-col ${className}`}>
            {name && <p className="m-2 mb-1 text-main-blue font-light">{name}</p>}
            <input
                type={type}
                name={name}
                value={value}
                className={`border-b mr-5 mb-[10px] rounded-sm block relative text-sm text-[#333] ${error ? 'border-red-500' : ''}`}
                onChange={onChange}/>
            {error && <span className="text-red-500 text-xs">{error}</span>} {/* Display error message */}
        </div>
    );
}
