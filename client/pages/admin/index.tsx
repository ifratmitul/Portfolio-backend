import AdminLayout from "../../components/layout/AdminLayout";
import AdminControlPanel from "../../AdminPanelComponents/AdminControlPanel/Admin.control-panel";
const AdminHome = () => {
  return (
    <>
      <div style={{ background: "orange" }}>AdminHome</div>
      <AdminControlPanel />
    </>
  );
};

AdminHome.layout = AdminLayout;

export default AdminHome;
