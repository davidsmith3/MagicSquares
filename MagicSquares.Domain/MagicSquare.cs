using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.Domain {
    struct Loc {
        public int r;
        public int c;

        public Loc(int r, int c) {
            this.r = r;
            this.c = c;
        }
    }

    public class MagicSquare {

        private int n;
        private int[,] sq;

        public MagicSquare(int n, string s) {
            if ((n % 2) != 1) throw new ArgumentException("n must be odd");
            if (n < 0) throw new ArgumentException("n must be positive");

            if ((s != "tuld") && 
                (s != "turd") &&
                (s != "llur") &&
                (s != "lldr") &&
                (s != "rrul") &&
                (s != "rrdl") &&
                (s != "bdlu") &&
                (s != "bdru")) throw new ArgumentException("invalid type");

            this.n = n;
            sq = new int[n, n];

            Loc current = GetStart(s.Substring(0, 1));
            for (int i = 1; i <= (n * n); i++) {
                sq[current.r, current.c] = i;
                current = GetNext(current, s.Substring(1, 2), s.Substring(3, 1));
            }
        }

        public MagicSquare(int[,] square) {
            int n = square.GetLength(0);
            if ((n % 2) != 1) throw new ArgumentException("n must be odd");
            if (square.GetLength(1) != n) throw new ArgumentException("input must be square");

            this.n = n;
            sq = new int[n, n];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    sq[i, j] = square[i, j];
                }
            }
        }

        private Loc GetStart(string s) {
            switch (s) {
                case "t": return new Loc(0, n / 2);
                case "b": return new Loc(n - 1, n / 2);
                case "l": return new Loc(n / 2, 0);
                case "r": return new Loc(n / 2, n - 1);
            }
            return new Loc();
        }

        private Loc GetNext(Loc current, string primary, string alternate) {
            Loc candidate = new Loc();
            switch (primary) {
                case "ul": 
                    candidate = GoLeft(GoUp(current));
                    break;
                case "ur": 
                    candidate = GoRight(GoUp(current));
                    break;
                case "lu":
                    candidate = GoUp(GoLeft(current));
                    break;
                case "ld":
                    candidate = GoDown(GoLeft(current));
                    break;
                case "ru":
                    candidate = GoUp(GoRight(current));
                    break;
                case "rd":
                    candidate = GoDown(GoRight(current));
                    break;
                case "dl":
                    candidate = GoLeft(GoDown(current));
                    break;
                case "dr":
                    candidate = GoRight(GoDown(current));
                    break;
            }
            if (sq[candidate.r, candidate.c] > 0) {
                switch (alternate) {
                    case "d":
                        candidate = GoDown(current);
                        break;
                    case "r":
                        candidate = GoRight(current);
                        break;
                    case "l":
                        candidate = GoLeft(current);
                        break;
                    case "u":
                        candidate = GoUp(current);
                        break;
                }
            }
            return candidate;
        }

        private Loc GoLeft(Loc current) {
            return new Loc(current.r, Wrap(current.c - 1));
        }

        private Loc GoRight(Loc current) {
            return new Loc(current.r, Wrap(current.c + 1));
        }

        private Loc GoUp(Loc current) {
            return new Loc(Wrap(current.r - 1), current.c);
        }

        private Loc GoDown(Loc current) {
            return new Loc(Wrap(current.r + 1), current.c);
        }

        private int Wrap(int x) {
            if (x == -1) x = n - 1;
            if (x == n) x = 0;
            return x;
        }

        public bool IsValid() {
            int sum = 0;
            for (int i = 0; i < n; i++) {
                sum += sq[0, i];
            }
            if (sum == 0) return false;

            /* sum rows */
            for (int r = 0; r < n; r++) {
                int rsum = 0;
                for (int c = 0; c < n; c++) {
                    rsum += sq[r, c];
                }
                if (rsum != sum) return false;
            }

            /* sum colums */
            for (int c = 0; c < n; c++) {
                int csum = 0;
                for (int r = 0; r < n; r++) {
                    csum += sq[r, c];
                }
                if (csum != sum) return false;
            }

            /* sum left diag */
            int lsum = 0;
            for (int l = 0; l < n; l++) {
                lsum += sq[l, l];
            }
            if (lsum != sum) return false;

            /* sum right diag */
            int rdsum = 0;
            for (int rd = 0; rd < n; rd++) {
                rdsum += sq[n - (rd + 1), rd];
            }
            if (rdsum != sum) return false;

            int digitMax = n * n;
            bool[] digits = new bool[digitMax + 1];
            for (int d = 1; d < (digitMax + 1); d++) {
                digits[d] = false;
            }
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (digits[sq[i, j]]) return false;
                    digits[sq[i, j]] = true;
                }
            }

            return true;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    sb.AppendFormat("{0}\t", sq[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
