using System.Drawing;
using System.Runtime.InteropServices;

namespace testConsoleApp
{
    internal class Program
    {
        const int RSERR_SUCC = 0;

        static UInt16 rshd = 0xffff;
        //机械臂IP地址
        const string robotIP = "192.168.50.10";//"192.168.50.10";//"127.0.0.1";//
                                               //机械臂端口号
        const int serverPort = 8899;

        #region
        //M_PI
        const double M_PI = 3.14159265358979323846;
        //接口板用户DI地址
        const int ROBOT_IO_F1 = 30;
        const int ROBOT_IO_F2 = 31;
        const int ROBOT_IO_F3 = 32;
        const int ROBOT_IO_F4 = 33;
        const int ROBOT_IO_F5 = 34;
        const int ROBOT_IO_F6 = 35;
        const int ROBOT_IO_U_DI_00 = 36;
        const int ROBOT_IO_U_DI_01 = 37;
        const int ROBOT_IO_U_DI_02 = 38;
        const int ROBOT_IO_U_DI_03 = 39;
        const int ROBOT_IO_U_DI_04 = 40;
        const int ROBOT_IO_U_DI_05 = 41;
        const int ROBOT_IO_U_DI_06 = 42;
        const int ROBOT_IO_U_DI_07 = 43;
        const int ROBOT_IO_U_DI_10 = 44;
        const int ROBOT_IO_U_DI_11 = 45;
        const int ROBOT_IO_U_DI_12 = 46;
        const int ROBOT_IO_U_DI_13 = 47;
        const int ROBOT_IO_U_DI_14 = 48;
        const int ROBOT_IO_U_DI_15 = 49;
        const int ROBOT_IO_U_DI_16 = 50;
        const int ROBOT_IO_U_DI_17 = 51;

        //接口板用户DO地址
        const int ROBOT_IO_U_DO_00 = 32;
        const int ROBOT_IO_U_DO_01 = 33;
        const int ROBOT_IO_U_DO_02 = 34;
        const int ROBOT_IO_U_DO_03 = 35;
        const int ROBOT_IO_U_DO_04 = 36;
        const int ROBOT_IO_U_DO_05 = 37;
        const int ROBOT_IO_U_DO_06 = 38;
        const int ROBOT_IO_U_DO_07 = 39;
        const int ROBOT_IO_U_DO_10 = 40;
        const int ROBOT_IO_U_DO_11 = 41;
        const int ROBOT_IO_U_DO_12 = 42;
        const int ROBOT_IO_U_DO_13 = 43;
        const int ROBOT_IO_U_DO_14 = 44;
        const int ROBOT_IO_U_DO_15 = 45;
        const int ROBOT_IO_U_DO_16 = 46;
        const int ROBOT_IO_U_DO_17 = 47;

        //接口板用户AI地址
        const int ROBOT_IO_VI0 = 0;
        const int ROBOT_IO_VI1 = 1;
        const int ROBOT_IO_VI2 = 2;
        const int ROBOT_IO_VI3 = 3;

        //接口板用户AO地址
        const int ROBOT_IO_VO0 = 0;
        const int ROBOT_IO_VO1 = 1;
        const int ROBOT_IO_CO0 = 2;
        const int ROBOT_IO_CO1 = 3;

        //接口板IO类型
        //
        //接口板用户DI(数字量输入)　可读可写
        const int Robot_User_DI = 4;
        //接口板用户DO(数字量输出)  可读可写
        const int Robot_User_DO = 5;
        //接口板用户AI(模拟量输入)  可读可写
        const int Robot_User_AI = 6;
        //接口板用户AO(模拟量输出)  可读可写
        const int Robot_User_AO = 7;

        //工具端IO类型
        //
        //工具端DI
        const int Robot_Tool_DI = 8;
        //工具端DO
        const int Robot_Tool_DO = 9;
        //工具端AI
        const int Robot_Tool_AI = 10;
        //工具端AO
        const int Robot_Tool_AO = 11;
        //工具端DI
        const int Robot_ToolIoType_DI = Robot_Tool_DI;
        //工具端DO
        const int Robot_ToolIoType_DO = Robot_Tool_DO;

        //工具端IO名称
        const string TOOL_IO_0 = ("T_DI/O_00");
        const string TOOL_IO_1 = ("T_DI/O_01");
        const string TOOL_IO_2 = ("T_DI/O_02");
        const string TOOL_IO_3 = ("T_DI/O_03");

        //工具端数字IO类型
        //
        //输入
        const int TOOL_IO_IN = 0;
        //输出
        const int TOOL_IO_OUT = 0;

        //工具端电源类型
        //
        const int OUT_0V = 0;
        const int OUT_12V = 1;
        const int OUT_24V = 2;

        //IO状态-无效
        const double IO_STATUS_INVALID = 0.0;
        //IO状态-有效
        const double IO_STATUS_VALID = 1.0;

        //坐标系枚举
        const int BaseCoordinate = 0;
        const int EndCoordinate = 1;
        const int WorldCoordinate = 2;

        //坐标系标定方法
        const int Origin_AnyPointOnPositiveXAxis_AnyPointOnPositiveYAxis = 0; // 原点、x轴正半轴、y轴正半轴
        const int Origin_AnyPointOnPositiveYAxis_AnyPointOnPositiveZAxis = 1; // 原点、y轴正半轴、z轴正半轴
        const int Origin_AnyPointOnPositiveZAxis_AnyPointOnPositiveXAxis = 2; // 原点、z轴正半轴、x轴正半轴
        const int Origin_AnyPointOnPositiveXAxis_AnyPointOnFirstQuadrantOfXOYPlane = 3; // 原点、x轴正半轴、x、y轴平面的第一象限上任意一点
        const int Origin_AnyPointOnPositiveXAxis_AnyPointOnFirstQuadrantOfXOZPlane = 4; // 原点、x轴正半轴、x、z轴平面的第一象限上任意一点
        const int Origin_AnyPointOnPositiveYAxis_AnyPointOnFirstQuadrantOfYOZPlane = 5; // 原点、y轴正半轴、y、z轴平面的第一象限上任意一点
        const int Origin_AnyPointOnPositiveYAxis_AnyPointOnFirstQuadrantOfYOXPlane = 6; // 原点、y轴正半轴、y、x轴平面的第一象限上任意一点
        const int Origin_AnyPointOnPositiveZAxis_AnyPointOnFirstQuadrantOfZOXPlane = 7; // 原点、z轴正半轴、z、x轴平面的第一象限上任意一点
        const int Origin_AnyPointOnPositiveZAxis_AnyPointOnFirstQuadrantOfZOYPlane = 8; // 原点、z轴正半轴、z、y轴平面的第一象限上任意一点

        //工具标定方法
        const int ToolKinematicsOriCalibrateMathod_xOxy = 0;                   // 原点、x轴正半轴、x、y轴平面的第一象限上任意一点
        const int ToolKinematicsOriCalibrateMathod_yOyz = 1;                  // 原点、y轴正半轴、y、z轴平面的第一象限上任意一点
        const int ToolKinematicsOriCalibrateMathod_zOzx = 2;                  // 原点、z轴正半轴、z、x轴平面的第一象限上任意一点
        const int ToolKinematicsOriCalibrateMathod_TxRBz_TxyPBzAndTyABnz = 3;  // 工具x轴平行反向于基坐标系z轴; 工具xOy平面平行于基坐标系z轴、工具y轴与基坐标系负z轴夹角为锐角
        const int ToolKinematicsOriCalibrateMathod_TyRBz_TyzPBzAndTzABnz = 4;  // 工具y轴平行反向于基坐标系z轴; 工具yOz平面平行于基坐标系z轴、工具z轴与基坐标系负z轴夹角为锐角
        const int ToolKinematicsOriCalibrateMathod_TzRBz_TzxPBzAndTxABnz = 5;  // 工具z轴平行反向于基坐标系z轴; 工具zOx平面平行于基坐标系z轴、工具x轴与基坐标系负z轴夹角为锐角

        //运动轨迹类型
        //
        //圆
        const int ARC_CIR = 2;
        //圆弧
        const int CARTESIAN_MOVEP = 3;

        //机械臂状态
        const int RobotStopped = 0;
        const int RobotRunning = 1;
        const int RobotPaused = 2;
        const int RobotResumed = 3;

        //机械臂工作模式
        const int RobotModeSimulator = 0; //机械臂仿真模式
        const int RobotModeReal = 1; //机械臂真实模式

        #endregion



        static void Main(string[] args)
        {



            cSharpBinding csharpbingding = new cSharpBinding();
            double end_max_angle_velc = 3;
            double end_max_angle_acc = 3;
            double[] joint_max_velc = { 1.5, 1.5, 1.5, 1.5, 1.5, 1.5 };
            double[] joint_max_acc = { 5, 5, 5, 5, 5, 5 };
            double io_status = 0;
            int result = 0xffff;
            Console.Out.WriteLine("call rs_initialize");

            //初始化机械臂控制库
            result = cSharpBinding.rs_initialize();
            Console.Out.WriteLine("rs_initialize.ret={0}", result);

            if (RSERR_SUCC == result)
            {
                //创建机械臂控制上下文句柄
                if (cSharpBinding.rs_create_context(ref rshd) == RSERR_SUCC)
                {
                    Console.Out.WriteLine("rshd={0}", rshd);
                    //链接机械臂服务器

                    int testInt = cSharpBinding.rs_login(rshd, robotIP, serverPort);
                    Console.Out.WriteLine("TestIntCodeBy.rs_login: {0}", testInt);
                    if (testInt == RSERR_SUCC)
                    {
                        Console.Out.WriteLine("login succ.");
                        cSharpBinding.ToolDynamicsParam tool = new cSharpBinding.ToolDynamicsParam { positionX = 0, positionY = 0, positionZ = 0, payload = 0, };
                        tool.toolInertia = new cSharpBinding.ToolInertia { xx = 0, xy = 0, xz = 0, yy = 0, yz = 0, zz = 0 };
                        int state = 0;

                        result = cSharpBinding.rs_robot_startup(rshd,
                                                             ref tool,
                                                             6        /*Collision level*/,
                                                             true     /*Whether to allow reading poses defaults to true*/,
                                                             true,    /*Leave the default to true */
                                                             1000,    /*Leave the default to 1000 */
                                                             ref state);


                        cSharpBinding.wayPoint_S waypoint = new cSharpBinding.wayPoint_S();
                        cSharpBinding.JointVelcAccParam temp = new cSharpBinding.JointVelcAccParam();
                        //直接获取机械臂当前位置信息
                        cSharpBinding.rs_get_current_waypoint(rshd, ref waypoint);
                        //打印路点信息
                        cSharpBinding.PrintWaypoint(waypoint);

                        //根据错误号返回错误信息
                        int err_code = 10024;
                        IntPtr _errinfo = cSharpBinding.rs_get_error_information_by_errcode(rshd, err_code);
                        string err_information = Marshal.PtrToStringAnsi(_errinfo);
                        Console.Out.WriteLine("err_information is:{0}", err_information);
                        Console.Out.WriteLine("---------------------------------------------------------------------------------------");
                        //设置碰撞等级
                        int grade = 2;
                        cSharpBinding.rs_set_collision_class(rshd, grade);
                        Console.Out.WriteLine("set robot collision ret is:{0}", +grade);
                        //获取当前碰撞等级
                        int current_grade = 0;
                        cSharpBinding.rs_get_collision_class(rshd, ref current_grade);
                        Console.Out.WriteLine("current grade is:{0}", current_grade);
                        Console.Out.WriteLine("---------------------------------------------------------------------------------------");
                        //初始化全局的运动属性
                        cSharpBinding.rs_init_global_move_profile(rshd);

                        //设置六个关节轴动的最大加速度
                        cSharpBinding.rs_set_global_joint_maxacc(rshd, joint_max_acc);

                        //设置六个关节轴动的最大速度
                        cSharpBinding.rs_set_global_joint_maxvelc(rshd, joint_max_velc);

                        //获取六个关节轴动的最大速度
                        cSharpBinding.rs_get_global_joint_maxvelc(rshd, ref temp);
                        Console.Out.WriteLine("joint max velc = {0},{1},{2},{3},{4},{5}",
                        temp.jointPara[0], temp.jointPara[1], temp.jointPara[2],
                        temp.jointPara[3], temp.jointPara[4], temp.jointPara[5]);

                        //获取六个关节轴动的最大加速度
                        cSharpBinding.rs_get_global_joint_maxacc(rshd, ref temp);
                        Console.Out.WriteLine("joint max acc = {0},{1},{2},{3},{4},{5}",
                        temp.jointPara[0], temp.jointPara[1], temp.jointPara[2],
                        temp.jointPara[3], temp.jointPara[4], temp.jointPara[5]);

                        //设置末端型运动旋转最大角加速度
                        cSharpBinding.rs_set_global_end_max_angle_acc(rshd, end_max_angle_acc);
                        //设置末端型运动旋转最大角速度
                        cSharpBinding.rs_set_global_end_max_angle_velc(rshd, end_max_angle_velc);
                        //获取末端型运动旋转最大角加速度
                        double get_end_max_angle_acc = 0;
                        cSharpBinding.rs_get_global_end_max_angle_acc(rshd, ref get_end_max_angle_acc);
                        Console.Out.WriteLine("end max angle acc = {0}", get_end_max_angle_acc);
                        //获取末端型运动旋转最大角速度
                        double get_end_max_angle_velc = 0;
                        cSharpBinding.rs_get_global_end_max_angle_velc(rshd, ref get_end_max_angle_velc);
                        Console.Out.WriteLine("end max angle velc = {0}", get_end_max_angle_velc);
                        Console.Out.WriteLine("---------------------------------------------------------------------------------------");

                        cSharpBinding.rs_logout(rshd);
                    }
                    else
                    {
                        Console.Error.WriteLine("login failed!");

                    }
                    //注销机械臂控制上下文句柄
                    cSharpBinding.rs_destory_context(rshd);
                }
                else
                {
                    Console.Error.WriteLine("rs_create_context failed!");
                }

                //反初始化机械臂控制库
                cSharpBinding.rs_uninitialize();
            }
            else
            {
                Console.Error.WriteLine("rs_initialize failed!");
            }

            Console.Out.WriteLine("bye");

            Console.ReadKey();
        }

        private static void rs_get_current_waypoint(ushort rshd, ref cSharpBinding.wayPoint_S waypoint)
        {
            throw new NotImplementedException();
        }
    }
}