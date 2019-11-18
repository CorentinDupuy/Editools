using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Editool_Unity
{
    public static class ButtonEdit
    {
        public static void Button(string _buttonContent, Action _callBack, bool _showCondition = true)
        {
            if (!_showCondition) return;
            if(GUILayout.Button(_buttonContent))
            {
                _callBack?.Invoke();
            }
        }

        public static void Button<T1>(string _buttonContent, Action<T1> _callBack, T1 arg0, bool _showCondition = true)
        {
            if (!_showCondition) return;
            if (GUILayout.Button(_buttonContent))
            {
                _callBack?.Invoke(arg0);
            }
        }

        public static void Button(string _buttonContent, Action _callBack, Color _color, bool _showCondition = true)
        {
            if (!_showCondition) return;
            GUI.color = _color;
            if (GUILayout.Button(_buttonContent))
            {
                _callBack?.Invoke();
            }
            GUI.color = Color.white;
        }
        public static void Button<T1, T2>(string _buttonContent, Action<T1, T2> _callBack, Color _color, T1 arg0, T2 arg1, bool _showCondition = true)
        {
            if (!_showCondition) return;
            GUI.color = _color;
            if (GUILayout.Button(_buttonContent))
            {
                _callBack?.Invoke(arg0, arg1);
            }
            GUI.color = Color.white;
        }

        public static void ButtonConfirmation(string _buttonContent, Action _callBack, Color _color, string _title, string _message, string _acceptButton, string _cancelButton, bool _showCondition = true)
        {
            if (!_showCondition) return;
            GUI.color = _color;
            if (GUILayout.Button(_buttonContent))
            {
                bool _confirm = EditorUtility.DisplayDialog(_title, _message, _acceptButton, _cancelButton);
                if (_confirm) _callBack?.Invoke();
            }
            GUI.color = Color.white;
        }

        public static void ButtonConfirmation<T1>(string _buttonContent, Action<T1> _callBack, Color _color, string _title, string _message, string _acceptButton, string _cancelButton, T1 arg0, bool _showCondition = true)
        {
            if (!_showCondition) return;
            GUI.color = _color;
            if (GUILayout.Button(_buttonContent))
            {
                bool _confirm = EditorUtility.DisplayDialog(_title, _message, _acceptButton, _cancelButton);
                if (_confirm) _callBack?.Invoke(arg0);
            }
            GUI.color = Color.white;
        }
        public static void ButtonConfirmation<T1, T2>(string _buttonContent, Action<T1, T2> _callBack, Color _color, string _title, string _message, string _acceptButton, string _cancelButton, T1 arg0, T2 arg1, bool _showCondition = true)
        {
            if (!_showCondition) return;
            GUI.color = _color;
            if (GUILayout.Button(_buttonContent))
            {
                    bool _confirm = EditorUtility.DisplayDialog(_title, _message, _acceptButton, _cancelButton);
                if(_confirm) _callBack?.Invoke(arg0, arg1);
            }
            GUI.color = Color.white;
        }
    }

    public static class Layout
    {
        public static void Space(int _i = 1)
        {
            for (int i = 0; i < _i; i++)
            {
                EditorGUILayout.Space();
            }
        }

        public static void Horizontal(bool _open)
        {
            if (_open) EditorGUILayout.BeginHorizontal();
            else EditorGUILayout.EndHorizontal();
        }

        public static void Vertical(bool _open)
        {
            if (_open) EditorGUILayout.BeginVertical();
            else EditorGUILayout.EndVertical();
        }

        public static bool Foldout(ref bool foldout, string content, bool toggleOnLabelClick) => foldout = EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick);

        public static void HelpBox(string _message) => EditorGUILayout.HelpBox(_message, MessageType.None);

        public static void HelpBoxWarning(string _message) => EditorGUILayout.HelpBox(_message, MessageType.Warning);

        public static void HelpBoxInfo(string _message) => EditorGUILayout.HelpBox(_message, MessageType.Info);

        public static void HelpBoxError(string _message) => EditorGUILayout.HelpBox(_message, MessageType.Error);

        public static void Vector3(string _message, Vector3 _position) => _position = EditorGUILayout.Vector3Field(_message, _position);

        public static void Object<T1>(Object _object, T1 _type, bool _print) => EditorGUILayout.ObjectField(_object, _type.GetType(), _print);

        public static Enum Popup(string _message, Enum _type) => EditorGUILayout.EnumPopup(_message, _type);

        public static int Slider(string _message, int _value, int _min, int _max) => EditorGUILayout.IntSlider(_message, _value, _min, _max);
    }
}

public class EditorCustom<T> : Editor where T : MonoBehaviour
{
    protected T eTarget = default(T);

    protected virtual void OnEnable()
    {
        eTarget = (T)target;
        eTarget.name = $"[{typeof(T).Name}]";
    }
}

public class HandleTool
{
    public static void DrawCube(Vector3 _position, Vector3 _size) => Handles.DrawWireCube(_position, _size);
    public static void DrawCube(Vector3 _position, Vector3 _size, Color _color)
    {
        Handles.color = _color;
        Handles.DrawWireCube(_position, _size);
        Handles.color = Color.white;
    }

    public static void DrawDisc(Vector3 _position, Vector3 _normal, float _radius) => Handles.DrawWireDisc(_position, _normal, _radius);

    public static void DrawDisc(Vector3 _position, Vector3 _normal, float _radius, Color _color)
    {
        Handles.color = _color;
        Handles.DrawWireDisc(_position, _normal, _radius);
        Handles.color = Color.white;
    }

    public static void DrawLine(Vector3 _origin, Vector3 _position, float _size) => Handles.DrawDottedLine(_origin, _position, _size);
    public static void DrawLine(Vector3 _origin, Vector3 _position, float _size, Color _color)
    {
        Handles.color = _color;
        Handles.DrawDottedLine(_origin, _position, _size);
        Handles.color = Color.white;
    }

    public static void CubeHandle(int _id, Vector3 _position, Quaternion _rotation, float _size, EventType _type) => Handles.CubeHandleCap(_id, _position, _rotation, _size, _type);

    public static Vector3 Position(Vector3 _position, Quaternion _rotation) => Handles.PositionHandle(_position, _rotation);

    public static Vector3 Size(Vector3 _scale, Vector3 _position, Quaternion _rotation, float _size) => Handles.ScaleHandle(_scale, _position, _rotation, _size);
}


