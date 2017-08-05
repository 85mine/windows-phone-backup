using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameXepHinh.Controller
{
    class Khoitao
    {
        public int Loai_Khoi { get; set; }
        //loai 1 Khoi L
        //loai 2 Khoi Z nguoc
        public int kieu { get; set; }
        public int Loai_Khoi2 { get; set; }
        //loai 1 Khoi L
        //loai 2 Khoi Z nguoc
        public int kieu2 { get; set; }
        public void New_KhoiL()
        {
            Update_Matrix.matrix[4, 4] = 1;
            Update_Matrix.matrix[4, 5] = 1;
            Update_Matrix.matrix[3, 5] = 1;
            Update_Matrix.matrix[2, 5] = 1;

        }
        public bool Kiemtra_Khoitao(int x, int y)
        {
            bool IsKhoitao = false;
            if (Loai_Khoi == 1)
            {
                switch (kieu)
                {
                    case 1:
                        if (x - 2 >= 0 && y + 1 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 2, y + 1] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 2: if (x - 1 >= 0 && y < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 2] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 2 >= 0 && y + 1 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y + 1] != 3)
                        {
                            IsKhoitao = true;
                            //    return IsKhoitao;
                        }
                        break;
                    case 4:
                        if (x - 1 >= 0 && y + 2 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x, y + 2] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3)
                        {
                            IsKhoitao = true;
                            //   return IsKhoitao;
                        }
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 2)
            {
                switch (kieu)
                {
                    case 1: if (x - 2 >= 0 && y - 1 >= 0 && y < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 1] != 3 &&
                        Update_Matrix.matrix[x - 2, y - 1] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 2: if (x + 2 < 23 && y + 2 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x + 1, y + 1] != 3 &&
                        Update_Matrix.matrix[x + 2, y + 2] != 3
                          )
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 2 >= 0 && y - 1 >= 0 && y < 10 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y - 1] != 3 &&
                         Update_Matrix.matrix[x - 2, y - 1] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 4: if (x + 2 < 23 && y + 2 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x, y + 1] != 3 &&
                         Update_Matrix.matrix[x + 1, y + 1] != 3 &&
                         Update_Matrix.matrix[x + 2, y + 2] != 3
                           )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            else if (Loai_Khoi == 3)
            {
                switch (kieu)
                {
                    case 1: if (x - 2 >= 0 && y >= 0 && y + 1 < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 2, y + 1] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 2: if (x - 1 >= 0 && y + 1 < 10 && y - 1 >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 1] != 3
                          )
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 2 >= 0 && y >= 0 && y + 1 < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 2, y + 1] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 4: if (x - 1 >= 0 && y + 1 < 10 && y - 1 >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x, y + 1] != 3 &&
                         Update_Matrix.matrix[x - 1, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y - 1] != 3
                           )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            else if (Loai_Khoi == 4)
            {
                switch (kieu)
                {
                    case 1: if (x - 2 >= 0 && y >= 0 && y + 1 < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 2: if (x - 1 >= 0 && y + 2 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x, y + 2] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 2] != 3
                          )
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 2 >= 0 && y - 1 >= 0 && y < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y - 1] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 4: if (x - 1 >= 0 && y + 2 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                         Update_Matrix.matrix[x - 1, y + 2] != 3
                           )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            else if (Loai_Khoi == 4)
            {
                switch (kieu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4: if (x - 1 >= 0 && y + 1 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                         Update_Matrix.matrix[x, y + 1] != 3
                           )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            //////////////KHOI TAO
            else if (Loai_Khoi == 6)
            {
                switch (kieu)
                {
                    case 1: if (x - 1 >= 0 && y - 1 >= 0 && y + 1 < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 1] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 2: if (x - 2 >= 0 && y < 10 && y - 1 >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y - 1] != 3
                          )
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 1 >= 0 && y >= 0 && y + 2 < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x - 1, y + 1] != 3 &&
                        Update_Matrix.matrix[x, y + 2] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 4: if (x - 2 >= 0 && y + 1 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y] != 3 &&
                         Update_Matrix.matrix[x - 2, y] != 3 &&
                         Update_Matrix.matrix[x - 1, y + 1] != 3
                           )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            else if (Loai_Khoi == 7)
            {
                switch (kieu)
                {
                    case 1: if (x - 3 >= 0 && y >= 0 && y < 10 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x - 1, y] != 3 &&
                        Update_Matrix.matrix[x - 2, y] != 3 &&
                        Update_Matrix.matrix[x - 3, y] != 3)
                        {
                            IsKhoitao = true;
                        }

                        break;
                    case 2: if (x >= 0 && y + 3 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                        Update_Matrix.matrix[x, y + 1] != 3 &&
                        Update_Matrix.matrix[x, y + 2] != 3 &&
                        Update_Matrix.matrix[x, y + 3] != 3
                          )
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 3: if (x - 3 >= 0 && y >= 0 && y < 10 && Update_Matrix.matrix[x, y] != 3 &&
                       Update_Matrix.matrix[x - 1, y] != 3 &&
                       Update_Matrix.matrix[x - 2, y] != 3 &&
                       Update_Matrix.matrix[x - 3, y] != 3)
                        {
                            IsKhoitao = true;
                        }
                        break;
                    case 4: if (x >= 0 && y + 3 < 10 && y >= 0 && Update_Matrix.matrix[x, y] != 3 &&
                       Update_Matrix.matrix[x, y + 1] != 3 &&
                       Update_Matrix.matrix[x, y + 2] != 3 &&
                       Update_Matrix.matrix[x, y + 3] != 3
                         )
                        {
                            IsKhoitao = true;
                        }
                        break;
                }
            }
            return IsKhoitao;
        }
        public void Khoitao_mau(int x, int y)
        {
            if (Loai_Khoi == 1)
            {
                switch (kieu)
                {
                    case 1:

                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 2, y + 1] = Update_Matrix.Im_Index[0];
                        break;
                    case 2:

                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y - 2] = Update_Matrix.Im_Index[0];

                        break;
                    case 3:

                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 2, y + 1] = Update_Matrix.Im_Index[0];

                        break;
                    case 4:

                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x, y + 2] = Update_Matrix.Im_Index[0];
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0];
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 2)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 2: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 2] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 3: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 2] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 3)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y + 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 2: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 3: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y + 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 4)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 2: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 2] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 2] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 3: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 2] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 5)
            {
                switch (kieu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 6)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 2: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y - 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 3: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 2] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y + 1] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 7)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 3, y] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 2: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 2] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 3] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 3: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 1, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 2, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x - 3, y] = Update_Matrix.Im_Index[0]; ;
                        break;
                    case 4: Update_Matrix.matrix_mau[x, y] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 1] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 2] = Update_Matrix.Im_Index[0]; ;
                        Update_Matrix.matrix_mau[x, y + 3] = Update_Matrix.Im_Index[0]; ;
                        break;
                    default: break;
                }
            }
        }
        public void Khoitao_Khoi(int x, int y)
        {
            if (Loai_Khoi == 1)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 2, y + 1] = 1;
                        break;
                    case 2:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        Update_Matrix.matrix[x - 1, y - 2] = 1;

                        break;
                    case 3:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 2, y + 1] = 1;

                        break;
                    case 4:

                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 2] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;

                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 2)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        Update_Matrix.matrix[x - 2, y - 1] = 1;
                        break;
                    case 2: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 2] = 1;
                        break;
                    case 3: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        Update_Matrix.matrix[x - 2, y - 1] = 1;
                        break;
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 2] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 3)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 2, y + 1] = 1;
                        break;
                    case 2: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        break;
                    case 3: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 2, y + 1] = 1;
                        break;
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 4)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        break;
                    case 2: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 2] = 1;
                        Update_Matrix.matrix[x - 1, y + 2] = 1;
                        break;
                    case 3: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 2, y - 1] = 1;
                        break;
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 2] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 5)
            {
                switch (kieu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 6)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        break;
                    case 2: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 1, y - 1] = 1;
                        break;
                    case 3: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 2] = 1;
                        break;
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 1, y + 1] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi == 7)
            {
                switch (kieu)
                {
                    case 1:
                        Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 3, y] = 1;
                        break;
                    case 2: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 2] = 1;
                        Update_Matrix.matrix[x, y + 3] = 1;
                        break;
                    case 3: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x - 1, y] = 1;
                        Update_Matrix.matrix[x - 2, y] = 1;
                        Update_Matrix.matrix[x - 3, y] = 1;
                        break;
                    case 4: Update_Matrix.matrix[x, y] = 1;
                        Update_Matrix.matrix[x, y + 1] = 1;
                        Update_Matrix.matrix[x, y + 2] = 1;
                        Update_Matrix.matrix[x, y + 3] = 1;
                        break;
                    default: break;
                }
            }
        }
        public void Khoitao_Khoinho(int x, int y)
        {
            if (Loai_Khoi2 == 1)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 2, y + 1] = 1;

                        break;
                    case 2:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 2] = 1;

                        break;
                    case 3:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y + 1] = 1;

                        break;
                    case 4:

                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 2] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;

                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi2 == 2)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        Hinhnen.matrix_nho[x - 2, y - 1] = 1;
                        break;
                    case 2: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 2] = 1;
                        break;
                    case 3: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        Hinhnen.matrix_nho[x - 2, y - 1] = 1;
                        break;
                    case 4: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 2] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi2 == 3)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 2, y + 1] = 1;
                        break;
                    case 2: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        break;
                    case 3: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 2, y + 1] = 1;
                        break;
                    case 4: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        break;
                    default: break;
                }
            }
            else if (Loai_Khoi2 == 4)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        break;
                    case 2: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 2] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 2] = 1;
                        break;
                    case 3: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y - 1] = 1;
                        break;
                    case 4: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 2] = 1;
                        break;
                    default: break;
                }

            }
            else if (Loai_Khoi2 == 5)
            {
                switch (kieu2)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        break;
                    default: break;
                }

            }
            else if (Loai_Khoi2 == 6)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        break;
                    case 2: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y - 1] = 1;
                        break;
                    case 3: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 2] = 1;
                        break;
                    case 4: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y + 1] = 1;
                        break;
                    default: break;
                }

            }
            else if (Loai_Khoi2 == 7)
            {
                switch (kieu2)
                {
                    case 1:
                        Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 3, y] = 1;
                        break;
                    case 2: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 2] = 1;
                        Hinhnen.matrix_nho[x, y + 3] = 1;
                        break;
                    case 3: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x - 1, y] = 1;
                        Hinhnen.matrix_nho[x - 2, y] = 1;
                        Hinhnen.matrix_nho[x - 3, y] = 1;
                        break;
                    case 4: Hinhnen.matrix_nho[x, y] = 1;
                        Hinhnen.matrix_nho[x, y + 1] = 1;
                        Hinhnen.matrix_nho[x, y + 2] = 1;
                        Hinhnen.matrix_nho[x, y + 3] = 1;
                        break;
                    default: break;
                }

            }
        }
    }
}
