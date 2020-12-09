using UnityEngine;

namespace BGD.FirsPersonMovement
{
    [CreateAssetMenu(fileName = "Key", menuName = "Key/PoolKeyInput", order = 1)]
    public class PoolKeyInput : ScriptableObject
    {
        [SerializeField] private string _vertical = "input";
        [SerializeField] private string _horizontal = "input";

        [SerializeField] private string _run = "input";
        [SerializeField] private string _jump = "input";
        [SerializeField] private string _seet = "input";

        [SerializeField] private string _mouseX = "input";
        [SerializeField] private string _mouseY = "input";

        public string Vertical => _vertical;
        public string Horizontal => _horizontal;
        public string Run => _run;
        public string Jump => _jump;
        public string Seet => _seet;

        public string MouseX => _mouseX;
        public string MouseY => _mouseY;
    }
}