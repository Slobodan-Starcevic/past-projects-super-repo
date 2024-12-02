import { Link } from "react-router-dom";
import Pagination from '@mui/material/Pagination';
import PaginationItem from '@mui/material/PaginationItem';

export default function PaginationComponent({ currentPage, totalPages, onPageChange, baseUrl }) {
    return (
        <Pagination
            count={totalPages}
            page={currentPage}
            onChange={(event, page) => onPageChange(page)}
            renderItem={(item) => {
                let linkUrl = `${baseUrl}?page=${item.page}`;

                if (item.type === 'previous') {
                    linkUrl = `${baseUrl}?page=${currentPage - 1}`;
                } else if (item.type === 'next') {
                    linkUrl = `${baseUrl}?page=${currentPage + 1}`;
                }

                return (
                    <PaginationItem
                        {...item}
                        component={Link}
                        to={linkUrl}
                    />
                );
            }}
        />
    );
}
