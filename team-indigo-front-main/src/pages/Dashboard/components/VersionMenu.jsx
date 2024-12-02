import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import PropTypes from 'prop-types';

const VersionMenu = ({ anchorEl, handleClose, handleSelect, versions }) => {
    const versionNumbers = Array.from({ length: versions }, (_, i) => i + 1).reverse();

    return (
        <Menu
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={handleClose}
            MenuListProps={{ sx: { padding: 0 } }}
            sx={{
                margin: 0,
                borderRadius: '1px',
                '& .MuiMenu-list': { padding: 0 },
            }}
            anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
            transformOrigin={{ vertical: 'top', horizontal: 'center' }}
        >
            <MenuItem
                key={versions + 1}
                onClick={()=>{
                    handleSelect("latest")
                }}
            >
                Latest
            </MenuItem>
            {versionNumbers.map(versionNumber => (
                <MenuItem
                    key={versionNumber}
                    onClick={() => handleSelect(versionNumber)}
                >
                    Version {versionNumber}
                </MenuItem>
            ))}
        </Menu>
    );
};

VersionMenu.propTypes = {
    anchorEl: PropTypes.any,
    handleClose: PropTypes.func.isRequired,
    handleSelect: PropTypes.func.isRequired,
    versions: PropTypes.number.isRequired
};

export default VersionMenu;
