using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// EPX-64S API library definitions
/// </summary>

namespace RCC300A100Tester
{

    public class EPX64S
    {
        // Function definitions
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_GetNumberOfDevices(ref int Number);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_GetSerialNumber(int Index, ref int SerialNumber);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_Open(ref System.IntPtr Handle);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_OpenBySerialNumber(int SerialNumber, ref System.IntPtr Handle);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_Close(System.IntPtr Handle);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_SetDirection(System.IntPtr Handle, byte Direction);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_GetDirection(System.IntPtr Handle, ref byte Direction);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_OutputPort(System.IntPtr Handle, byte Port, byte Value);
        [DllImport("EPX64S.dll")]
        public static extern int EPX64S_InputPort(System.IntPtr Handle, byte Port, ref byte Value);


        // Device status (Return codes)
        public const int EPX64S_OK = 0;
        public const int EPX64S_INVALID_HANDLE = 1;
        public const int EPX64S_DEVICE_NOT_FOUND = 2;
        public const int EPX64S_DEVICE_NOT_OPENED = 3;
        public const int EPX64S_OTHER_ERROR = 4;
        public const int EPX64S_COMMUNICATION_ERROR = 5;
        public const int EPX64S_INVALID_PARAMETER = 6;

        // Constants
        public const byte EPX64S_PORT0 = 0x01;
        public const byte EPX64S_PORT1 = 0x02;
        public const byte EPX64S_PORT2 = 0x04;
        public const byte EPX64S_PORT3 = 0x08;
        public const byte EPX64S_PORT4 = 0x10;
        public const byte EPX64S_PORT5 = 0x20;
        public const byte EPX64S_PORT6 = 0x40;
        public const byte EPX64S_PORT7 = 0x80;


        //�񋓌^
        public enum PORT
        {
            P0, P1, P2, P3, P4, P5, P6, P7,
        }

        public enum BIT
        {
            b0, b1, b2, b3, b4, b5, b6, b7,
        }

        public enum OUT
        {
            H, L,
        }


        //�v���p�e�B

        //�C���X�^���X�ϐ��錾�i��������C���X�^���X�ŗL�̒l�j
        private System.IntPtr hDevice;   //Device Handle�i�|�C���^�ւ̃|�C���^�j
        public int Status { get; private set; }   // Device Status (Return Code)
        private int Number;              // Devices Number
        private byte Direction;          //�e�|�[�g ����or�o�͂̐ݒ�p�p�����[�^
        private byte Port;               //���o�͂̃|�[�g�w��p�p�����[�^
        private byte InputValue;         //�w��|�[�g����ǂݍ��񂾃f�[�^

        public byte P0InputData { get; private set; } //�|�[�g0�̓��̓f�[�^�o�b�t�@
        public byte P1InputData { get; private set; } //�|�[�g1�̓��̓f�[�^�o�b�t�@
        public byte P2InputData { get; private set; } //�|�[�g2�̓��̓f�[�^�o�b�t�@
        public byte P3InputData { get; private set; } //�|�[�g3�̓��̓f�[�^�o�b�t�@
        public byte P4InputData { get; private set; } //�|�[�g4�̓��̓f�[�^�o�b�t�@
        public byte P5InputData { get; private set; } //�|�[�g5�̓��̓f�[�^�o�b�t�@
        public byte P6InputData { get; private set; } //�|�[�g6�̓��̓f�[�^�o�b�t�@
        public byte P7InputData { get; private set; } //�|�[�g7�̓��̓f�[�^�o�b�t�@

        public byte p0Outdata { get; private set; } //���݂̃|�[�g�O�ɏo�͂���Ă���f�[�^
        public byte p1Outdata { get; private set; } //���݂̃|�[�g�P�ɏo�͂���Ă���f�[�^
        public byte p2Outdata { get; private set; } //���݂̃|�[�g�Q�ɏo�͂���Ă���f�[�^
        public byte p3Outdata { get; private set; } //���݂̃|�[�g�R�ɏo�͂���Ă���f�[�^
        public byte p4Outdata { get; private set; } //���݂̃|�[�g�S�ɏo�͂���Ă���f�[�^
        public byte p5Outdata { get; private set; } //���݂̃|�[�g�T�ɏo�͂���Ă���f�[�^
        public byte p6Outdata { get; private set; }  //���݂̃|�[�g�U�ɏo�͂���Ă���f�[�^
        public byte p7Outdata { get; private set; }  //���݂̃|�[�g�V�ɏo�͂���Ă���f�[�^

        //�C���X�^���X�R���X�g���N�^
        public EPX64S()
        {
            //�C���X�^���X�ϐ��̏�����
            hDevice = System.IntPtr.Zero;   // Device Handle
            Status = 1; // ����������0�ȊO�Ƃ��Ă���
            Number = 0; // Devices Number
            Direction = 0;
            Port = 0;
            InputValue = 0;

            P0InputData = 0; //���݂̃|�[�g�O�ɏo�͂���Ă���f�[�^
            P1InputData = 0; //���݂̃|�[�g�P�ɏo�͂���Ă���f�[�^
            P2InputData = 0; //���݂̃|�[�g�Q�ɏo�͂���Ă���f�[�^
            P3InputData = 0; //���݂̃|�[�g�R�ɏo�͂���Ă���f�[�^
            P4InputData = 0; //���݂̃|�[�g�S�ɏo�͂���Ă���f�[�^
            P5InputData = 0; //���݂̃|�[�g�T�ɏo�͂���Ă���f�[�^
            P6InputData = 0; //���݂̃|�[�g�U�ɏo�͂���Ă���f�[�^
            P7InputData = 0; //���݂̃|�[�g�V�ɏo�͂���Ă���f�[�^

            p0Outdata = 0; //���݂̃|�[�g�O�ɏo�͂���Ă���f�[�^
            p1Outdata = 0; //���݂̃|�[�g�P�ɏo�͂���Ă���f�[�^
            p2Outdata = 0; //���݂̃|�[�g�Q�ɏo�͂���Ă���f�[�^
            p3Outdata = 0; //���݂̃|�[�g�R�ɏo�͂���Ă���f�[�^
            p4Outdata = 0; //���݂̃|�[�g�S�ɏo�͂���Ă���f�[�^
            p5Outdata = 0; //���݂̃|�[�g�T�ɏo�͂���Ă���f�[�^
            p6Outdata = 0; //���݂̃|�[�g�U�ɏo�͂���Ă���f�[�^
            p7Outdata = 0; //���݂̃|�[�g�V�ɏo�͂���Ă���f�[�^
        }

        //**************************************************************************
        //EPX64�̏�����
        //�����F�Ȃ�
        //�ߒl�F�Ȃ�
        //**************************************************************************
        public bool InitEpx64S(byte DirectionData)
        {
            try
            {
                // Device Number
                EPX64S_GetNumberOfDevices(ref this.Number);
                if (this.Number == 0) return false;

                // Device Open
                this.Status = EPX64S_Open(ref this.hDevice);
                if (this.Status != EPX64S_OK) return false;

                // Direction 0=���� 1=�o��
                this.Direction = DirectionData;//��0x07��P7:0 P6:0 P5:0 P4:0 P3:0 P2:1 P1:1 P0:1
                this.Status = EPX64S_SetDirection(this.hDevice, this.Direction);
                return (this.Status == EPX64S_OK);
            }
            catch
            {
                return false;
            }

        }

        //****************************************************************************
        //���\�b�h���FReadInputData�i�w��|�[�g�̃f�[�^����荞�ށj
        //�����F�|�[�g���i"P0"�A"P1"�E�E�E"P7"�j
        //�߂�l�F��荞�񂾃f�[�^����O�A�ُ�P
        //****************************************************************************
        public bool ReadInputData(PORT pName)
        {
            try
            {
                switch (pName)
                {
                    case PORT.P0:
                        this.Port = EPX64S_PORT0; // PORT0
                        break;
                    case PORT.P1:
                        this.Port = EPX64S_PORT1; // PORT1
                        break;
                    case PORT.P2:
                        this.Port = EPX64S_PORT2; // PORT2                   
                        break;
                    case PORT.P3:
                        this.Port = EPX64S_PORT3; // PORT3                   
                        break;
                    case PORT.P4:
                        this.Port = EPX64S_PORT4; // PORT4                   
                        break;
                    case PORT.P5:
                        this.Port = EPX64S_PORT5; // PORT5                  
                        break;
                    case PORT.P6:
                        this.Port = EPX64S_PORT6; // PORT6                   
                        break;
                    case PORT.P7:
                        this.Port = EPX64S_PORT7; // PORT7                     
                        break;
                    default:
                        break;
                }

                // Input
                foreach (var i in Enumerable.Range(1, 2))
                {
                    this.Status = EPX64S_InputPort(this.hDevice, this.Port, ref this.InputValue);
                    if (Status == EPX64S_OK)
                        break;
                    if (i == 2)
                    {
                        return false;
                    }                
                }

                switch (pName)
                {
                    case PORT.P0:
                        this.P0InputData = this.InputValue;
                        break;
                    case PORT.P1:
                        this.P1InputData = this.InputValue;
                        break;
                    case PORT.P2:
                        this.P2InputData = this.InputValue;
                        break;
                    case PORT.P3:
                        this.P3InputData = this.InputValue;
                        break;
                    case PORT.P4:
                        this.P4InputData = this.InputValue;
                        break;
                    case PORT.P5:
                        this.P5InputData = this.InputValue;
                        break;
                    case PORT.P6:
                        this.P6InputData = this.InputValue;
                        break;
                    case PORT.P7:
                        this.P7InputData = this.InputValue;
                        break;
                }
                return true;
            }
            catch
            {
                this.Status = EPX64S.EPX64S_COMMUNICATION_ERROR;
                return false;
            }


        }



        //****************************************************************************
        //���\�b�h���FOutByte�i�w��|�[�g�Ƀo�C�g�P�ʂł̏o�́j
        //�����F�����@�@�|�[�g���i"P0"�A"P1"�E�E�E"P7"�j�����A�o�͒l�i0x00�`0xFF�j
        //�߂�l�F����O�A�ُ�P
        //****************************************************************************
        public bool OutByte(PORT pName, byte Data)
        {
            try
            {
                //�|�[�g�̓���Əo�̓f�[�^�o�b�t�@�̍X�V
                switch (pName)
                {
                    case PORT.P0:
                        this.Port = EPX64S_PORT0;
                        this.p0Outdata = Data;
                        break;
                    case PORT.P1:
                        this.Port = EPX64S_PORT1;
                        this.p1Outdata = Data;
                        break;
                    case PORT.P2:
                        this.Port = EPX64S_PORT2;
                        this.p2Outdata = Data;
                        break;
                    case PORT.P3:
                        this.Port = EPX64S_PORT3;
                        this.p3Outdata = Data;
                        break;
                    case PORT.P4:
                        this.Port = EPX64S_PORT4;
                        this.p4Outdata = Data;
                        break;
                    case PORT.P5:
                        this.Port = EPX64S_PORT5;
                        this.p5Outdata = Data;
                        break;
                    case PORT.P6:
                        this.Port = EPX64S_PORT6;
                        this.p6Outdata = Data;
                        break;
                    case PORT.P7:
                        this.Port = EPX64S_PORT7;
                        this.p7Outdata = Data;
                        break;
                    default:
                        break;
                }

                //�f�[�^�̏o��
                this.Status = EPX64S_OutputPort(this.hDevice, this.Port, Data);
                return (Status == EPX64S_OK) ? true : false;

            }
            catch
            {
                this.Status = EPX64S.EPX64S_COMMUNICATION_ERROR;
                return false;

            }
        }

        //****************************************************************************
        //���\�b�h���FOutBit�i�w��|�[�g�Ƀr�b�g�P�ʂł̏o�́j
        //�����F�����@�@�|�[�g���i"P00"�A"P01"�E�E�E"P07"�j�����A�o�͒l�iH�F0/ L: 1�j
        //�߂�l�Fbool
        //****************************************************************************
        public bool OutBit(PORT pName, BIT bName, OUT data)
        {

            byte buffOutData = 0; //�����_�ŏo�͂��Ă���f�[�^

            try
            {

                //�|�[�g�̓���
                switch (pName)
                {
                    case PORT.P0:
                        this.Port = EPX64S_PORT0;
                        buffOutData = this.p0Outdata;
                        break;
                    case PORT.P1:
                        this.Port = EPX64S_PORT1;
                        buffOutData = this.p1Outdata;
                        break;
                    case PORT.P2:
                        this.Port = EPX64S_PORT2;
                        buffOutData = this.p2Outdata;
                        break;
                    case PORT.P3:
                        this.Port = EPX64S_PORT3;
                        buffOutData = this.p3Outdata;
                        break;
                    case PORT.P4:
                        this.Port = EPX64S_PORT4;
                        buffOutData = this.p4Outdata;
                        break;
                    case PORT.P5:
                        this.Port = EPX64S_PORT5;
                        buffOutData = this.p5Outdata;
                        break;
                    case PORT.P6:
                        this.Port = EPX64S_PORT6;
                        buffOutData = this.p6Outdata;
                        break;
                    case PORT.P7:
                        this.Port = EPX64S_PORT7;
                        buffOutData = this.p7Outdata;
                        break;
                    default:
                        break;
                }

                //�r�b�g�̓���
                byte Temp = 0;
                int Num = 0;

                switch (bName)
                {
                    case BIT.b0:
                        Num = 0; Temp = 0xFE;
                        break;
                    case BIT.b1:
                        Num = 1; Temp = 0xFD;
                        break;
                    case BIT.b2:
                        Num = 2; Temp = 0xFB;
                        break;
                    case BIT.b3:
                        Num = 3; Temp = 0xF7;
                        break;
                    case BIT.b4:
                        Num = 4; Temp = 0xEF;
                        break;
                    case BIT.b5:
                        Num = 5; Temp = 0xDF;
                        break;
                    case BIT.b6:
                        Num = 6; Temp = 0xBF;
                        break;
                    case BIT.b7:
                        Num = 7; Temp = 0x7F;
                        break;
                }


                //�f�[�^�̏o��
                byte Data = 0;
                switch (data)
                {
                    case OUT.H:
                        Data = 1;
                        break;

                    case OUT.L:
                        Data = 0;
                        break;
                }

                //�w��r�b�g�ȊO�͂��̂܂܂ɂ��ďo�̓f�[�^�����肷��
                byte OutputValue = (byte)((buffOutData & Temp) | (Data << Num));//byte�ŷ��Ă��Ȃ��Ɠ{����

                //�o�̓f�[�^�o�b�t�@�̍X�V
                switch (pName)
                {
                    case PORT.P0:
                        this.p0Outdata = OutputValue;
                        break;
                    case PORT.P1:
                        this.p1Outdata = OutputValue;
                        break;
                    case PORT.P2:
                        this.p2Outdata = OutputValue;
                        break;
                    case PORT.P3:
                        this.p3Outdata = OutputValue;
                        break;
                    case PORT.P4:
                        this.p4Outdata = OutputValue;
                        break;
                    case PORT.P5:
                        this.p5Outdata = OutputValue;
                        break;
                    case PORT.P6:
                        this.p6Outdata = OutputValue;
                        break;
                    case PORT.P7:
                        this.p7Outdata = OutputValue;
                        break;
                }

                //�f�[�^�o��
                this.Status = EPX64S_OutputPort(this.hDevice, Port, OutputValue);
                return (Status == EPX64S_OK) ? true : false;

            }
            catch
            {
                this.Status = EPX64S.EPX64S_COMMUNICATION_ERROR;
                return false;
                
            }
        }


        //****************************************************************************
        //���\�b�h���FClose�i�|�[�g����鏈���j
        //�����F�Ȃ�
        //�߂�l�Fbool
        //****************************************************************************
        public bool Close()
        {
            try
            {
                EPX64S_Close(this.hDevice);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
