import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import PropTypes from 'prop-types';

const TodoMenu = ({ anchorEl, handleClose, handleEdit, handleDelete, status }) => (
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

        {status !== "complete" && (
            <MenuItem
                onClick={handleEdit}
                sx={{textAlign: 'center', paddingX: 3, color: '#4081e5', '&:hover': { backgroundColor: '#e3f2fd' }, fontFamily: 'Roboto, sans-serif', fontWeight: 400 }}
            >
                EDIT
            </MenuItem>
        )}
        <MenuItem
            onClick={handleDelete}
            sx={{textAlign: 'center', paddingX: 3, color: '#ff5959', '&:hover': { backgroundColor: '#ffebee' }, fontFamily: 'Roboto, sans-serif', fontWeight: 400 }}
        >
            DELETE
        </MenuItem>
    </Menu>
);

TodoMenu.propTypes = {
    anchorEl: PropTypes.any,
    handleClose: PropTypes.func.isRequired,
    handleEdit: PropTypes.func.isRequired,
    handleDelete: PropTypes.func.isRequired,
};

export default TodoMenu;
